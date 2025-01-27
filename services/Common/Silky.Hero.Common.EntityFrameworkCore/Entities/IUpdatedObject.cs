﻿namespace Silky.Hero.Common.EntityFrameworkCore.Entities;

public interface IUpdatedObject : IHasUpdatedTime
{
    long? UpdatedBy { get; set; }
}