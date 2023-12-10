import { describe, it, expect } from 'vitest';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import PayslipDisplay from './PayslipDisplay';

describe('PayslipDisplay', () => {
    it('renders nothing when payslip is null', () => {
        render(<PayslipDisplay payslip={null} />);
        expect(screen.queryByText('Payslip')).toBeNull();
    });

    it('renders payslip information correctly', () => {
        const mockPayslip: PaySlipDto = {
            name: 'John Doe',
            payPeriod: 'January 2023',
            grossIncome: 5000,
            incomeTax: 500,
            netIncome: 4500,
            super: 450,
        };

        render(<PayslipDisplay payslip={mockPayslip} />);

        expect(screen.getByText('Payslip')).toBeInTheDocument();
        expect(screen.getByText('Name')).toBeInTheDocument();
        expect(screen.getByText('John Doe')).toBeInTheDocument();
        expect(screen.getByText('Pay Period')).toBeInTheDocument();
        expect(screen.getByText('January 2023')).toBeInTheDocument();
    });
});
