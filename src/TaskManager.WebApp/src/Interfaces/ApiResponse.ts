import { TodoTask } from "./TodoTask";

export interface ApiResponse {
    data: TodoTask[];
    succeeded: boolean;
    error: string | null;
  }