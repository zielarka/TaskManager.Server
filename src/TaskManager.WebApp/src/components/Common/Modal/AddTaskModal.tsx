import React, { useState, useEffect } from 'react';
import Modal from 'react-modal';
import { addTask, editTask } from '~/app/api/todoTask/route';
import { TodoTask } from '~/Interfaces/TodoTask';
import { v4 as uuidv4 } from 'uuid';
import DateSelector from '~/components/UI/DateSelector';

interface AddTaskModalProps {
  isOpen: boolean;
  onRequestClose: () => void;
  onSubmit: (task: TodoTask) => void;
  task?: TodoTask; 
}

const AddTaskModal: React.FC<AddTaskModalProps> = ({ isOpen, onRequestClose, onSubmit, task }) => {
  const [taskId, setTaskId] = useState('');
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [status, setStatus] = useState(0);
  const [dueDate, setDueDate] = useState('');

  useEffect(() => {
    if (task) {
      setTaskId(task.id);
      setTitle(task.title);
      setDescription(task.description);
      setStatus(task.status);
      setDueDate(task.dueDate);
    } else {
      setTaskId('');
      setTitle('');
      setDescription('');
      setStatus(0);
      setDueDate('');
    }
  }, [task, isOpen]); 

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      if (task) {
        const updatedTask: TodoTask = {
          id: taskId, 
          title,
          description,
          status,
          dueDate,
        };
        const editedTask = await editTask(updatedTask);
        onSubmit(editedTask);
      } else {
        const newTask: TodoTask = {
          id: uuidv4(), 
          title,
          description,
          status,
          dueDate,
        };
        const addedTask = await addTask(newTask);
        onSubmit(addedTask);
      }
      onRequestClose();
    } catch (error) {
      if (error instanceof Error) {
        console.error(`Error ${task ? 'editing' : 'adding'} task:`, error.message);
      } else {
        console.error('Unexpected error:', error);
      }
    }
  };

  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onRequestClose}
      contentLabel={`${task ? 'Edit' : 'Add'} Task Modal`}
      className="fixed inset-0 flex items-center justify-center"
      overlayClassName="fixed inset-0 bg-black bg-opacity-50"
    >
      <div className="bg-white rounded-lg shadow-lg p-6 w-96">
        <h2 className="text-xl mb-4">{task ? 'Edit Task' : 'Add New Task'}</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label className="block text-sm font-bold mb-2">Title</label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              type="text"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              required
            />
          </div>
          <div className="mb-4">
            <label className="block text-sm font-bold mb-2">Description</label>
            <textarea
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              required
            />
          </div>
          <div className="mb-4">
            <label className="block text-sm font-bold mb-2">Status</label>
            <select
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              value={status}
              onChange={(e) => setStatus(parseInt(e.target.value))}
              required
            >
              <option value={0}>ToDo</option>
              <option value={1}>InProgress</option>
              <option value={2}>Done</option>
              <option value={3}>OnHold</option>
            </select>
          </div>
          <div className="mb-4">
            <DateSelector selectedDate={dueDate} onDateChange={setDueDate} inputType="datetime-local" labelName='Choose a due date for the task:' required />
          </div>
          <div className="flex items-center justify-between">
            <button
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
              type="submit"
            >
              {task ? 'Edit Task' : 'Add Task'}
            </button>
            <button
              className="bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
              type="button"
              onClick={onRequestClose}
            >
              Cancel
            </button>
          </div>
        </form>
      </div>
    </Modal>
  );
};

export default AddTaskModal;