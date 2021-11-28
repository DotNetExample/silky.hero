﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Silky.Core;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Hero.Common.Exceptions;

namespace Silky.Identity.Domain;

public class IdentityUserManager : UserManager<IdentityUser>
{
    private IRepository<UserSubsidiary> UserSubsidiaryRepository { get; }

    public IdentityUserManager(IdentityUserStore store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<IdentityUser> passwordHasher,
        IEnumerable<IUserValidator<IdentityUser>> userValidators,
        IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<IdentityUserManager> logger,
        IRepository<UserSubsidiary> userSubsidiaryRepository)
        : base(store,
            optionsAccessor,
            passwordHasher,
            userValidators,
            passwordValidators,
            keyNormalizer,
            errors,
            services,
            logger)
    {
        UserSubsidiaryRepository = userSubsidiaryRepository;
    }

    public async Task<IdentityUser> GetByIdAsync(long id)
    {
        var user = await Store.FindByIdAsync(id.ToString(), CancellationToken);
        if (user == null)
        {
            throw new EntityNotFoundException(typeof(IdentityUser), id);
        }

        return user;
    }

    public async Task<IdentityResult> SetUserSubsidiaries(IdentityUser user,
        ICollection<UserSubsidiary> userSubsidiaries)
    {
        Check.NotNull(user, nameof(user));
        Check.NotNull(userSubsidiaries, nameof(userSubsidiaries));

        var currentUserSubsidiaries = await GetUserSubsidiariesAsync(user);

        var result =
            await RemoveFromUserSubsidiariesAsync(user, currentUserSubsidiaries.Except(userSubsidiaries).Distinct());
        if (!result.Succeeded)
        {
            return result;
        }

        result = await AddToUserSubsidiariesAsync(user, userSubsidiaries.Except(currentUserSubsidiaries).Distinct());
        if (!result.Succeeded)
        {
            return result;
        }

        return result;
    }

    private async Task<IEnumerable<UserSubsidiary>> GetUserSubsidiariesAsync(IdentityUser user)
    {
        var userSubsidiaries = UserSubsidiaryRepository.Where(p => p.UserId == user.Id);
        return await userSubsidiaries.ToListAsync();
    }

    private async Task<IdentityResult> AddToUserSubsidiariesAsync(IdentityUser user,
        IEnumerable<UserSubsidiary> userSubsidiaries)
    {
        foreach (var userSubsidiary in userSubsidiaries)
        {
            await UserSubsidiaryRepository.InsertAsync(userSubsidiary);
        }

        return IdentityResult.Success;
    }

    private async Task<IdentityResult> RemoveFromUserSubsidiariesAsync(IdentityUser user,
        IEnumerable<UserSubsidiary> userSubsidiaries)
    {
        foreach (var userSubsidiary in userSubsidiaries)
        {
            await UserSubsidiaryRepository.DeleteAsync(userSubsidiary);
        }

        return IdentityResult.Success;
    }

    public Task<IdentityUser> FindByPhoneNumberAsync(string phoneNumber)
    {
        return ((IdentityUserStore)Store).FindByPhoneNumberAsync(phoneNumber);
    }

    public Task<IdentityUser> FindByAccountAsync(string account, bool includeDetails = false)
    {
        ThrowIfDisposed();
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account));
        }

        account = NormalizeName(account);
        return ((IdentityUserStore)Store).FindByAccountAsync(account, includeDetails);
    }
}