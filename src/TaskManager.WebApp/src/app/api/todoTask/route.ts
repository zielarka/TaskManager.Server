import { TodoTask } from '~/Interfaces/TodoTask';

const API_URL = 'https://localhost:44387/api/ToDoTask';

export const fetchTasks = async (): Promise<TodoTask[]> => {
  const response = await fetch(`${API_URL}/GetTasks`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({}),
  });

  if (!response.ok) {
    throw new Error(`Failed to fetch tasks: ${response.statusText}`);
  }

  const result = await response.json();
  if (!result.succeeded) {
    throw new Error(result.error || 'Failed to fetch tasks');
  }

  return result.data;
};

export const addTask = async (task: TodoTask): Promise<TodoTask> => {
  const response = await fetch(API_URL, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      id: task.id,
      title: task.title,
      description: task.description,
      dueDate: task.dueDate,
      status: task.status,
    }),
  });

  if (!response.ok) {
    const errorDetails = await response.text();
    throw new Error(`Failed to add task: ${response.statusText} - ${errorDetails}`);
  }

  if (response.status === 204) {
    return task;
  }

  return await response.json();
};

export const editTask = async (task: TodoTask): Promise<TodoTask> => {
  const response = await fetch(API_URL, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      id: task.id,
      title: task.title,
      description: task.description,
      dueDate: task.dueDate,
      status: task.status,
    }),
  });

  if (!response.ok) {
    const errorDetails = await response.text();
    throw new Error(`Failed to edit task: ${response.statusText} - ${errorDetails}`);
  }

  if (response.status === 204) {
    return task;
  }

  return await response.json();
};

export const deleteTask = async (taskId: string): Promise<void> => {
  const response = await fetch(API_URL, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
      'Accept': '*/*',
    },
    body: JSON.stringify({ taskId }),
  });

  if (!response.ok) {
    const errorDetails = await response.text();
    throw new Error(`Failed to delete task: ${response.statusText} - ${errorDetails}`);
  }
};