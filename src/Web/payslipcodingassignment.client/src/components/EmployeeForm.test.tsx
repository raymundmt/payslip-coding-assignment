import { describe, it, expect, vi } from 'vitest';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import EmployeeForm from './EmployeeForm';

describe('EmployeeForm', () => {
    it('clears the form and calls onClear callback when Clear button is clicked', () => {
        const mockOnSubmit = vi.fn();
        const mockOnClear = vi.fn();

        render(<EmployeeForm onSubmit={mockOnSubmit} onClear={mockOnClear} />);

        fireEvent.click(screen.getByText('Clear'));

        expect(mockOnClear).toHaveBeenCalled();
    });
});
