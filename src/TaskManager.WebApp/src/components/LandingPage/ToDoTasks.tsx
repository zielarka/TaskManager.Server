import React, { useEffect, useState } from "react";
import { TodoTask } from "~/Interfaces/TodoTask";
import TaskCard from "../UI/TaskCard";
import AddTaskModal from "../Common/Modal/AddTaskModal";
import { deleteTask, editTask, fetchTasks } from "~/app/api/todoTask/route";
import DateSelector from "../UI/DateSelector";

interface Props {
  initialTasks: TodoTask[];
}

const ToDoTasks: React.FC<Props> = ({ initialTasks }) => {
  const [tasks, setTasks] = useState<TodoTask[]>(initialTasks || []);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [currentTask, setCurrentTask] = useState<TodoTask | null>(null);
  const [selectedStartDate, setSelectedStartDate] = useState<string>(
    new Date().toISOString().split("T")[0],
  );

  const openModal = () => setIsModalOpen(true);
  const closeModal = () => {
    setIsModalOpen(false);
    setCurrentTask(null); // Reset currentTask on close
  };

  useEffect(() => {
    const getTasks = async () => {
      try {
        const fetchedTasks = await fetchTasks();
        setTasks(fetchedTasks);
        console.log("Fetched tasks:", fetchedTasks);
      } catch (error) {
        console.error("Error fetching tasks:", error.message);
      }
    };

    getTasks();
  }, []);

  const openEditModal = (task: TodoTask) => {
    setCurrentTask(task);
    openModal();
  };

  const handleAddTask = (task: TodoTask) => {
    setTasks((prevTasks) => [...prevTasks, task]);
  };

  const handleEditTask = async (task: TodoTask) => {
    try {
      const updatedTask = await editTask(task);
      setTasks((prevTasks) =>
        prevTasks.map((t) =>
          t.id.toLowerCase() === updatedTask.id.toLowerCase() ? updatedTask : t,
        ),
      );
    } catch (error) {
      console.error("Error editing task:", error.message);
    }
  };

  const handleDeleteTask = async (taskId: string) => {
    try {
      await deleteTask(taskId);
      setTasks((prevTasks) =>
        prevTasks.filter(
          (task) => task.id.toLowerCase() !== taskId.toLowerCase(),
        ),
      );
    } catch (error) {
      console.error("Error deleting task:", error.message);
    }
  };

  const handleDateChange = (date: string) => {
    setSelectedStartDate(date);
  };

  const filteredTasks = tasks.filter((task) => {
    if (!task.dueDate) return false;
    const taskDueDate = new Date(task.dueDate);
    const selectedDate = new Date(selectedStartDate);

    return (
      taskDueDate.getFullYear() === selectedDate.getFullYear() &&
      taskDueDate.getMonth() === selectedDate.getMonth() &&
      taskDueDate.getDate() === selectedDate.getDate()
    );
  });

  console.log("Filtered tasks:", filteredTasks);

  return (
    <div className="container relative mx-auto p-4">
      <h1 className="mb-4 text-2xl font-bold">ToDo Tasks</h1>
      <DateSelector
        selectedDate={selectedStartDate}
        onDateChange={handleDateChange}
        inputType="date"
        labelName="Select Due Date"
      />
      <div className="grid grid-cols-1 gap-4 md:grid-cols-2 lg:grid-cols-3">
        {filteredTasks.length > 0 ? (
          filteredTasks.map((task) => (
            <TaskCard
              key={task.id}
              task={task}
              onEdit={() => openEditModal(task)}
              onDelete={() => handleDeleteTask(task.id)}
            />
          ))
        ) : (
          <p>No tasks available</p>
        )}
      </div>
      <button
        className="fixed bottom-4 right-4 rounded-full bg-blue-500 p-4 text-white shadow-lg hover:bg-blue-700"
        onClick={openModal}
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          className="h-6 w-6"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth={2}
            d="M12 4v16m8-8H4"
          />
        </svg>
      </button>
      <AddTaskModal
        isOpen={isModalOpen}
        onRequestClose={closeModal}
        onSubmit={currentTask ? handleEditTask : handleAddTask}
        task={currentTask || undefined}
      />
    </div>
  );
};

export default ToDoTasks;
