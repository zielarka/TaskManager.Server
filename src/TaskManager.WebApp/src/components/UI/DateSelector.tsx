import React from 'react';

interface DateSelectorProps {
  selectedDate: string;
  onDateChange: (date: string) => void;
  labelName: string;
  inputType: 'date' | 'datetime-local';
  required?: boolean; 
}

const DateSelector: React.FC<DateSelectorProps> = ({ selectedDate, onDateChange, labelName, inputType, required  }) => {
  return (
    <div className="mb-4">
      <label className="block text-sm font-bold mb-2">{labelName}</label>
      <input
        className="shadow appearance-none border rounded w-48 py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        type={inputType}
        value={selectedDate}
        onChange={(e) => onDateChange(e.target.value)}
        required={required}
      />
    </div>
  );
};

export default DateSelector;