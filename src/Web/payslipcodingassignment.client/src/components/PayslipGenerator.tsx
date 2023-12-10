import React, { useState } from 'react'
import PayslipDisplay from './PayslipDisplay'
import EmployeeForm from './EmployeeForm'
import { Space } from 'antd'
import { generatePayslip } from '../services/generatePayslip'

const PayslipGenerator: React.FC = () => {
    const [payslip, setPayslip] = useState<PaySlipDto | null>(null)

    const handleSubmit = async (formData: EmployeeInputDto) => {
        try {
            const generatedPayslip = await generatePayslip(formData)
            setPayslip(generatedPayslip)
        } catch (error) {
            console.error('Error generating payslip:', error)
            setPayslip(null)
        }
    }

    return (
        <Space direction="vertical" size="middle" className="app-form">
            <EmployeeForm onSubmit={handleSubmit} onClear={() => setPayslip(null)} />
            <PayslipDisplay payslip={payslip} />
        </Space>
    )
}

export default PayslipGenerator
