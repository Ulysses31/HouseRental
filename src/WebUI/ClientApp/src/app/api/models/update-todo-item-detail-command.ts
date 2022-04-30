/* tslint:disable */
/* eslint-disable */
import { PriorityLevel } from "./priority-level";
export interface UpdateTodoItemDetailCommand {
  id?: number;
  listId?: number;
  note?: null | string;
  priority?: PriorityLevel;
}
