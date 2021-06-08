# Hospital Management Application
This project took around 3 months with 4 members. We will be developing an enterprise software system to aid both our customers and staff. It is a web-based software, aimed at improving efficiency and workflow in our hospital. We aim to provide all the information in one place for customers, and help to simplify any administrative task, such as filling up personal particulars, making appointments, making payment, etc. 

For staff, they will be able to better manage their tasks at hand, as well as being up-to-date on information such as patient information and important activities such as meetings, etc.

# Tables of content
- [Motivations](#Motivations)
- [Task Allocation / Task Done](#Task-Allocation-/-Task-Done)
- [Libraries / Technologies Used](#Libraries-/-Technologies-Used)

## Motivations
### Lack of Price Information

When a customer wants to find out how much would a particular service cost, there is no such information on the website. (e.g. health checkup costs, medicine costs, specific treatment costs, etc.). The accurate costs might be hard to come up with but an approximate cost should be shown. Currently the only way for the customer to find out is to inquire at the location or make a phone call. We will be implementing such a price information list, making prices transparent to our customers.

### Users Accustomed to Legacy Systems

The system that is used by customers, especially internal staff is very old and the steps to achieve a goal (e.g. book an appointment, update client particulars, etc) has a long workflow and is inefficient but is still being used because users are accustomed to it. By developing a new and better system (e.g. better ui/ux, shorter workflow, etc.) it will improve the users satisfaction long-term. 

### Unorganized information and slow workflow

With more patients visiting our hospital, we have more information (e.g. patients records) to deal with. The current legacy system is not intended to handle large amounts of data as it was created a long time ago. It is very difficult to search for a particular person’s record as it's very messy. Getting records of patients requires going to another portal and searching which can be unpleasant.

## Task Allocation / Task Done
Each Team member target different user(s)

### Doctor & Admin - [Hui Feng](https://github.com/TLI-Tristan)
- Create and View medical record
- Login authentication using using ASP.NET Identity and OWIN authentication 
- Routing user to correct landing page
- Prevent and allow resource access according to the account’s role
- Assign and change role to account
- Disable account to prevent login
- Change account password for all account
- Sending broadcast email to all employees or all patients of hospital
- Reply to any feedback (if necessary)
- View all appointments made by patient

### Front Desk Receptionist - [Minh Hieu](https://github.com/schwahue)
- Register new patient
- Edit existing patient record
- Disable patient record
- Enable patient record
- Search patient record
- Retrieve patient record from database

### HR - [Jun Hui](https://github.com/jhlee2000)
-Create/View/Edit/Search Employee Records
- Upload Image & PDF for employee
- Create new payroll
- Process payroll
- Cancel payroll
- Create/Renew/View/Print Employee’s Contract
- Add/View schedule for employee

### Patient - [Matthew](https://github.com/huntereureka)
- Make appointment
- View made appointments
- View made appointments (classified as admin role)
- Make feedback
- View all feedbacks made
- View all feedbacks made (admin)


## Libraries / Technologies Used
- Visual Studio
- GitHub
- .NET
- AJAX
- Microsoft Identity
- SendGrid API

