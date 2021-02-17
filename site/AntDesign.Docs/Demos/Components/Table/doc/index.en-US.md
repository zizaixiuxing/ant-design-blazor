---
category: Components
cols: 1
type: Data Display
title: Table
cover: https://gw.alipayobjects.com/zos/alicdn/f-SbcX2Lx/Table.svg
---

A table displays rows of data.

## When To Use

- To display a collection of structured data.
- To sort, search, paginate, filter data.

## How To Use

Specify `dataSource` of Table as an array of data.


## API

### Table

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Bordered | Whether to show all table borders | boolean | false |  |
| DataSource | Data record array to be displayed | TItem\[] | - |  |
| Expandable | Config expandable content | [Expandable](#expandable) | - |  |
| Footer | Table footer renderer | function(currentPageData) | - |  |
| GetPopupContainer | The render container of dropdowns in table | string | 'body' |  |
| Loading | Loading status of table | boolean  | false |  |
| Locale | The i18n text including filter, sort, empty text, etc | TableLocale |  |  |
| Pagination | Config of pagination. You can ref table pagination | object | - |  |
| RowClassName | Row's className | `Func<record, index, string>` | - |  |
| RowKey | Row's unique key, could be a string or function that returns a string | string \| function(record): string | `key` | TODO |
| ScrollX | Set horizontal scrolling, can also be used to specify the width of the scroll area, could be number, percent value and ['max-content'](https://developer.mozilla.org/zh-CN/docs/Web/CSS/width#max-content) | string | - |
| ScrollY | Set vertical scrolling, can also be used to specify the height of the scroll area, could be string or number | string | - |
| ShowHeader | Whether to show table header | boolean | true | TODO |
| ShowSorterTooltip | The header show next sorter direction tooltip | boolean | true |  |
| Size | Size of table | `default` \| `middle` \| `small` | `default` |  |
| SortDirections | Supported sort way, could be `ascend`, `descend` | Array | \[`ascend`, `descend`] |  |
| Sticky | Set sticky header and scroll bar | boolean \| `{offsetHeader?: number, offsetScroll?: number, getContainer?: () => HTMLElement}` | - | TODO |
| Summary | Summary content | (currentData) => ReactNode | - | TODO  |
| TableLayout | The [table-layout](https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout) attribute of table element | - \| `auto` \| `fixed` | -<hr />`fixed` when header/columns are fixed, or using `column.ellipsis` | TODO |
| Title | Table title renderer | function(currentPageData) | - | TODO |
| OnChange | Callback executed when pagination, filters or sorter is changed | EventCallback<QueryModel> | - |  |
| OnHeaderRow | Set props on per header row | function(column, index) | - | TODO |
| OnRow | Set props on per row | function(record, index) | - | TODO |
| RowExpandable | Enable row can be expandable | (record) => bool | - |
| TreeChildren | Enable row can be expandable | (record) => record[] | - |


### Column

One of the Table `columns` prop for describing the table's columns, Column has the same API.

| Property | Description | Type | Default | Version |  |
| --- | --- | --- | --- | --- | --- |
| ColSpan | Span of this column's title | number | - |  |  |
| DataIndex | Display field of the data record, support nest path by string array | string \| string\[] | - |  |  |
| DefaultSortOrder | Default order of sorted values | `ascend` \| `descend` | - |  |  |
| Ellipsis | The ellipsis cell content, not working with sorter and filters for now.<br />tableLayout would be `fixed` when `ellipsis` is `true` or `{ showTitle?: boolean }` | boolean \| {showTitle?: boolean } | false | showTitle: 4.3.0 |  |



| Fixed | (IE not support) Set column to be fixed: `true`(same as left) `'left'` `'right'` | boolean \| string | false |  |  |
| Key | Unique key of this column, you can ignore this prop if you've set a unique `dataIndex` | string | - |  |  |
| Sortable |  If you need sort buttons only, set to `true` | bool | false | |
| SorterCompare | Sort function for local sort, see [`System.Collections.Generic.IComparer<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-5.0&WT.mc_id=DT-MVP-5003987). | `Func<TData, TData, int>` | - |  |  |
| ShowSorterTooltip | If header show next sorter direction tooltip, override `showSorterTooltip` in table | boolean | true |  |  |
| SortDirections | Supported sort way, override `sortDirections` in `Table`, could be `ascend`, `descend` | Array | \[`ascend`, `descend`] |  |  |
| Title | Title of this column | string | - |  |  |
| TitleTemplate | Title of this column | RenderFragment | - |  |  |
| Width | Width of this column | string \| number | - |  |  |


### RowSelection

Properties for row selection.

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Width | Set the width of the selection column | string \| number | `32px` |  |
| Type | `checkbox` or `radio` | `checkbox` \| `radio` | `checkbox` |  |
| SelectedRowKeys | Controlled selected row keys | string\[] \| number\[] | \[] |  |