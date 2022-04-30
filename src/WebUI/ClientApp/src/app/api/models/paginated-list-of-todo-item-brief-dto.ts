/* tslint:disable */
/* eslint-disable */
import { TodoItemBriefDto } from "./todo-item-brief-dto";
export interface PaginatedListOfTodoItemBriefDto {
  hasNextPage?: boolean;
  hasPreviousPage?: boolean;
  items?: null | Array<TodoItemBriefDto>;
  pageNumber?: number;
  totalCount?: number;
  totalPages?: number;
}
