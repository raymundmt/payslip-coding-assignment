import { Card, Descriptions } from 'antd'
import React from 'react'

type PayslipDisplayProps = {
    payslip: PaySlipDto | null
}

const PayslipDisplay: React.FC<PayslipDisplayProps> = ({ payslip }) => {
    if (!payslip) {
        return <></>
    }

    return (
        <Card title="Payslip" bordered={false}>
            <Descriptions bordered column={1}>
                <Descriptions.Item label="Name">{payslip.name}</Descriptions.Item>
                <Descriptions.Item label="Pay Period">{payslip.payPeriod}</Descriptions.Item>
                <Descriptions.Item label="Gross Income">${payslip.grossIncome.toFixed(2)}</Descriptions.Item>
                <Descriptions.Item label="Income Tax">${payslip.incomeTax.toFixed(2)}</Descriptions.Item>
                <Descriptions.Item label="Net Income">${payslip.netIncome.toFixed(2)}</Descriptions.Item>
                <Descriptions.Item label="Super">${payslip.super.toFixed(2)}</Descriptions.Item>
            </Descriptions>
        </Card>
    );
};

export default PayslipDisplay
