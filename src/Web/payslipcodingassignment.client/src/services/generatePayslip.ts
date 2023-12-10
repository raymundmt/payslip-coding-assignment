export async function generatePayslip(employeeData: EmployeeInputDto): Promise<any> {
    const response = await fetch('generate-payslip', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(employeeData),
    });

    if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || 'Error occurred while generating payslip')
    }

    return await response.json()
}