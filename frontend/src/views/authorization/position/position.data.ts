import { omit } from 'lodash-es';
import { getPositionList } from '/@/api/position';
import { statusOptions } from '/@/utils/status';
import { Status } from '/@/utils/status';
import { Tag } from 'ant-design-vue';
import { h } from 'vue';
import { OptionsItem } from '/@/utils/model';
import { BasicColumn } from '/@/components/Table';
import { FormSchema } from '/@/components/Table';
import { DescItem } from '../../../components/Description/src/typing';
import { commonTagRender } from '/@/utils/tagUtil';
import { formatToDate } from '/@/utils/dateUtil';

export const getPositionOptions = async (query: any) => {
  const positionList = await getPositionList(query);
  const positionOptions = positionList.reduce((prev, next: Recordable) => {
    if (next) {
      prev.push({
        ...omit(next, ['name', 'id']),
        label: next['name'],
        value: next['id'],
        disabled: next['status'] === Status.Invalid,
      });
    }
    return prev;
  }, [] as OptionsItem[]);
  return positionOptions;
};

export const columns: BasicColumn[] = [
  {
    title: '名称',
    dataIndex: 'name',
    width: 120,
  },
  {
    title: '状态',
    dataIndex: 'status',
    width: 80,
    customRender: ({ record }) => {
      const enable = record.status === Status.Valid;
      const color = enable ? 'green' : 'red';
      const text = enable ? '启用' : '停用';
      return h(Tag, { color: color }, () => text);
    },
  },
  {
    title: '排序',
    dataIndex: 'sort',
    width: 80,
  },
  {
    title: '备注',
    dataIndex: 'remark',
    width: 120,
  },
];

export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '名称',
    component: 'Input',
    colProps: { span: 6 },
  },
];

export const positionSchemas: FormSchema[] = [
  {
    field: 'name',
    component: 'Input',
    label: '名称',
    rules: [
      {
        required: true,
        message: '岗位标示不允许为空',
      },
      {
        max: 50,
        message: '岗位标示长度不允许超过50个字符',
        validateTrigger: ['change', 'blur'],
      },
    ],
  },
  {
    field: 'sort',
    component: 'InputNumber',
    label: '排序',
  },
  {
    field: 'status',
    label: '状态',
    component: 'RadioButtonGroup',
    componentProps: {
      options: statusOptions,
    },
    defaultValue: Status.Valid,
  },
  {
    field: 'remark',
    component: 'InputTextArea',
    label: '备注',
  },
];

export const positionDetailSchemas: DescItem[] = [
  {
    field: 'name',
    label: '名称',
  },
  {
    field: 'sort',
    label: '排序',
  },
  {
    field: 'remark',
    label: '备注',
    span: 2,
  },
  {
    label: '状态',
    field: 'status',
    render: (value) => {
      if (value === Status.Valid) {
        return commonTagRender('blue', '启用');
      } else {
        return commonTagRender('red', '停用');
      }
    },
  },
  {
    label: '创建时间',
    field: 'createdTime',
    render: (value) => {
      if (value) {
        return formatToDate(value, 'YYYY-MM-DD HH:MM:ss');
      }
      return null;
    },
  },
  {
    label: '最后更新时间',
    field: 'updatedTime',
    render: (value) => {
      if (value) {
        return formatToDate(value, 'YYYY-MM-DD HH:MM:ss');
      }
      return null;
    },
  },
];
