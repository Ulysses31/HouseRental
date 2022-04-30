/* tslint:disable */
/* eslint-disable */
import { PriorityLevelDto } from "./priority-level-dto";
import { TodoListDto } from "./todo-list-dto";
export interface TodosViewModel {
  lists?: null | Array<TodoListDto>;
  priorityLevels?: null | Array<PriorityLevelDto>;
}
