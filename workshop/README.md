# Specification

* Some employees work by the hour. They are paid an hourly rate that is one of the fields in their employee record.
They submit daily time cards that record the date and the number of hours worked. If they work more than 8 hours per
day, they are paid 1.5 times their normal rate for those extra hours.They are paid every Friday.

* Some employees are paid a flat salary. They are paid on the last working day of the month. Their monthly salary
is one of the fields in their employee record.

* Some of the salaried employees are also paid a commission based on their sales. They submit sales receipts that
record the date and the amount of the sale. Their commission rate is a field in their employee record. They are paid
every other Friday.

* Employees can select their method of payment. They may have their paychecks mailed to the postal address of their
choice, have their paychecks held for pickup by the paymaster, or request that their paychecks be directly deposited
into the bank account of their choice.

* Some employees belong to the union. Their employee record has a field for the weekly dues rate. Their dues must be
deducted from their pay. Also, the union may assess service charges against individual union members from time to time.
These service charges are submitted by the union on a weekly basis and must be deducted from the appropriate employee's
next pay amount.

* The payroll application will run once each working day and pay the appropriate employees on that day. The system will
told what date the employees are to be paid to, so it will generate payments for records from the last time the employee
was paid up to the specified date.

## Use Case 1: Add New Employee

A new employee is added by the receipt of an `AddEmp` transaction. The transaction contains the employee's name, address
and assigned employee number. The transaction has three forms:

	1. AddEmp <empId> "<name>" "<address>" H <hourlyRate>
	2. AddEmp <empId> "<name>" "<address>" S <monthlySalary>
	3. AddEmp <empId> "<name>" "<address>" C <monthlySalary> <commissionRate>

The employee record is created with its field assigned appropriately.

### Alternative 1: An error in the transaction structure

If the transaction structure is inappropriate, it is printed out in an error message, and no action is taken.

## Use Case 2: Deleting an Employee

Employees are deleted when a `DelEmp` transaction is received. The form of transaction is as follows:

	DelEmp <empId>

When this transaction is received, the appropriate employee record is deleted.

### Alternative 1: Invalid or unknown `empId`

If the `<empId>` field is not structured correctly or does not refer to a valid employee record, the transaction is printed with an error message, and no other action is taken.

## Use Case 3: Post a *Time Card*

On receipt of a `TimeCard` transaction, the system will create a time card record and associate it with the appropriate employee record.

	TimeCard <empId> <date> <hours>

### Alternative 1: The selected employee is not hourly

The system will print an appropriate error message and take no further action.

### Alternative 2: An error in the transaction structure

The system will print an appropriate error message and take no further action.

## Use Case 4: Post a *Sales Receipt*

On receipt of the `SalesReceipt` transaction, the system will create a new sales-receipt record and associate it with the appropriate commisioned employee.

	SalesReceipt <empId> <date> <amount>

### Alternative 1: The selected employee is not commisioned

The system will print an appropriate error message and take no further action.

### Alternative 2: An error in the transaction structure

The system will print an appropriate error message and take no further action.

## Use Case 5: Post a Union Service Charge

On receipt of this transaction, the system will create a service-charge record and associate it with the appropriate union member.

	ServiceCharge <memberId> <amount>

### Alternative 1: Poorly formed transaction

If the transaction is not well formed or if the `<memberId>` does not refer to an existing union member, the transaction is printed with an appropriate error message.

## Use Case 6: Changing Employee Details

Upon receipt of this transaction, the system will alter one of the details of the appropriate employee record. There are several possible variations to this transaction.

	ChgEmp <empId> Name <name>                         Change employee name
	ChgEmp <empId> Address <address>                   Change employee address
	ChgEmp <empId> Hourly <hourlyRate>                 Change to hourly
	ChgEmp <empId> Salaried <salary>                   Change to salaried
	ChgEmp <empId> Commissioned <hourlyRate> <rate>    Change to commissioned
	ChgEmp <empId> Hold                                Hold paycheck
	ChgEmp <empId> Direct <bank> <account>             Direct deposit
	ChgEmp <empId> Mail <address>                      Mail paycheck
	ChgEmp <empId> Member <memberId> Dues <rate>       Put employee in union
	ChgEmp <empId> NoMember                            Cut employee from union

### Alternative 1: TRansaction errors

If the structure of the transaction is improper, `<empId>` does not refer to a real employee, or a `<memberId>` already refers to a member, the system will print a suitable error and take no further action.

## Use Case 7: Run the Payroll for Today

On receipt of the payday transaction, the system finds all those employees that should be paid on the specified date. The system then determines how much they are owed and pays them according to their selected payment method. An audit-trail report is printed showing the action taken for each employee.

	Payday <date>