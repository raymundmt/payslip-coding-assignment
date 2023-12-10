import { Button, Card, Form, Input, InputNumber, Select, Space } from "antd"

const { Option } = Select

type EmployeeFormProps = {
    onSubmit: (formData: EmployeeInputDto) => void
    onClear: () => void
}

const EmployeeForm: React.FC<EmployeeFormProps> = ({ onSubmit, onClear }) => {
    const [form] = Form.useForm<EmployeeInputDto>()
    return (
        <Card title="Employee" bordered={false}>
            <Form onFinish={onSubmit} form={form} layout={"vertical"}>
                <Form.Item label="First Name" name="firstName" rules={[{ required: true }]}>
                    <Input />
                </Form.Item>
                <Form.Item label="Last Name" name="lastName" rules={[{ required: true }]}>
                    <Input />
                </Form.Item>
                <Form.Item label="Annual Salary" name="annualSalary" rules={[{ required: true }]}>
                    <InputNumber min={0} style={{ width: '100%' }} />
                </Form.Item>
                <Form.Item label="Super Rate" name="superRate" rules={[{ required: true }]}>
                    <InputNumber min={0} max={50} style={{ width: '100%' }} />
                </Form.Item>
                <Form.Item label="Pay Period" name="payPeriod" rules={[{ required: true }]}>
                    <Select placeholder="Select a month" allowClear showSearch>
                        {["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"].map(month => (
                            <Option key={month} value={month}>{month}</Option>
                        ))}
                    </Select>
                </Form.Item>
                <Form.Item>
                    <Space>
                        <Button type="primary" htmlType="submit">
                            Generate Payslip
                        </Button>
                        <Button type="primary" onClick={() => {
                            form.resetFields()
                            onClear()
                        }}>
                            Clear
                        </Button>
                    </Space>
                </Form.Item>
            </Form>
        </Card>
    )
}

export default EmployeeForm