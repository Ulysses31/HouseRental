/* tslint:disable */
/* eslint-disable */
import { TodoItemDto } from "./todo-item-dto";
export interface TodoListDto {
  colour?: null | string;
  id?: number;
  items?: null | Array<TodoItemDto>;
  title?: null | string;
}
