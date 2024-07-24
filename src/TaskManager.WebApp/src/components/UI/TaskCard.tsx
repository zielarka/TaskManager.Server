import { faEdit, faTrash } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";
import { TodoTask } from "~/Interfaces/TodoTask";

interface TaskCardProps {
  task: TodoTask;
  onEdit: () => void;
  onDelete: () => void;
}

const TaskCard: React.FC<TaskCardProps> = ({ task, onEdit, onDelete }) => {
  const getStatusClass = (status: number) => {
    switch (status) {
      case 0:
        return "text-blue-500";
      case 1:
        return "text-yellow-500";
      case 2:
        return "text-green-500";
      case 3:
        return "text-red-500";
      default:
        return "text-gray-500";
    }
  };

  const getStatusText = (status: number) => {
    switch (status) {
      case 0:
        return "ToDo";
      case 1:
        return "InProgress";
      case 2:
        return "Done";
      case 3:
        return "OnHold";
      default:
        return "Unknown";
    }
  };

  return (
    <div className="rounded-lg bg-white p-4 shadow-md">
      <h2 className="text-xl font-semibold">{task.title}</h2>
      <p className="text-gray-700">{task.description}</p>
      <p className="text-gray-500">
        Due Date: {new Date(task.dueDate).toLocaleString()}
      </p>
      <p className={`mt-2 ${getStatusClass(task.status)}`}>
        {getStatusText(task.status)}
      </p>
      <div className="mt-4 flex space-x-4">
        <button className="text-blue-500 hover:text-blue-700 text-2xl" onClick={onEdit}>
          <FontAwesomeIcon icon={faEdit} />
        </button>
        <button className="text-red-500 hover:text-red-700 text-2xl" onClick={onDelete}>
          <FontAwesomeIcon icon={faTrash} />
        </button>
      </div>
    </div>
  );
};

export default TaskCard;
