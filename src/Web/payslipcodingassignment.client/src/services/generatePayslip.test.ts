import { describe, it, expect, vi, afterEach } from 'vitest';
import { generatePayslip } from './generatePayslip';

describe('generatePayslip', () => {
    afterEach(() => {
        vi.restoreAllMocks()
    })

    it('should return a successful response', async () => {
        const mockEmployeeData: EmployeeInputDto = {
            "firstName": "John",
            "lastName": "Smith",
            "annualSalary": 60050,
            "superRate": 9,
            "payPeriod": "March"
        };
        const mockResponse = {
            "name": "John Smith",
            "payPeriod": "01 March - 31 March",
            "grossIncome": 5004.17,
            "incomeTax": 919.58,
            "netIncome": 4084.59,
            "super": 450.38
        };
        vi.spyOn(global, 'fetch').mockResolvedValue({
            ok: true,
            json: async () => mockResponse,
        } as Response);

        const result = await generatePayslip(mockEmployeeData);
        expect(result).toEqual(mockResponse);
        expect(fetch).toHaveBeenCalledWith('generate-payslip', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(mockEmployeeData),
        });
    });

    it('should throw an error for a failed response', async () => {
        const mockEmployeeData: EmployeeInputDto = {
            "firstName": "",
            "lastName": "Smith",
            "annualSalary": 60050,
            "superRate": 9,
            "payPeriod": "March"
        };
        const mockError = { message: 'Error occurred' };

        vi.spyOn(global, 'fetch').mockResolvedValue({
            ok: false,
            json: async () => mockError,
        } as Response);

        await expect(generatePayslip(mockEmployeeData)).rejects.toThrow('Error occurred');
    });

    it('should throw default error for a failed response without message', async () => {
        const mockEmployeeData: EmployeeInputDto = {
            "firstName": "",
            "lastName": "Smith",
            "annualSalary": 60050,
            "superRate": 9,
            "payPeriod": "March"
        };
        const mockError = {};

        vi.spyOn(global, 'fetch').mockResolvedValue({
            ok: false,
            json: async () => mockError,
        } as Response);

        await expect(generatePayslip(mockEmployeeData)).rejects.toThrow('Error occurred while generating payslip');
    });
});
