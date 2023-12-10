import { describe, it, expect, vi, Mock } from 'vitest';
import { render, screen, waitFor, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import PayslipGenerator from './PayslipGenerator';
import { generatePayslip } from '../services/generatePayslip';

vi.mock('./EmployeeForm', () => {
    const MockEmployeeForm = ({ onSubmit }: { onSubmit: (data: any) => void }) => (
        <button onClick={() => onSubmit({
            "name": "John Smith",
            "payPeriod": "01 March - 31 March",
            "grossIncome": 5004.17,
            "incomeTax": 919.58,
            "netIncome": 4084.59,
            "super": 450.38
        })}>Submit Form</button>
    );
    return { default: MockEmployeeForm };
});

vi.mock('../services/generatePayslip', () => ({
    generatePayslip: vi.fn().mockResolvedValue({
        name: 'John Doe',
        payPeriod: 'January 2023',
        grossIncome: 5000,
        incomeTax: 500,
        netIncome: 4500,
        super: 450,
    }),
}));

describe('PayslipGenerator', () => {
    it('should generate a payslip on form submission', async () => {
        render(<PayslipGenerator />);
        fireEvent.click(screen.getByText('Submit Form'));

        await waitFor(() => {
            expect(generatePayslip).toHaveBeenCalled();
            expect(screen.getByText('Payslip')).toBeInTheDocument();
        });
    });

    it('should handle error on form submission', async () => {
        (generatePayslip as Mock).mockRejectedValueOnce(new Error('Mock Error'));

        render(<PayslipGenerator />);
        fireEvent.click(screen.getByText('Submit Form'));

        await waitFor(() => {
            expect(generatePayslip).toHaveBeenCalled();
            expect(screen.queryByText('Payslip')).toBeNull();
        });
    });
});