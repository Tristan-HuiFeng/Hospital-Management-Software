
/* Start of HR */
INSERT dbo.EMPLOYEE
VALUES ('T0000000D', 'Pierre', 'Gasly', 'pierregasly@gmail.com', '19940101', 'M', '123 Street, Singapore', 'HR', 'HR Manager', 'French', 'None', 'pierregasly', '123', 'HR');

INSERT dbo.EMPLOYEE
VALUES ('T0000001D', 'Lance', 'Stroll', 'lancestroll@gmail.com', '19970101', 'M', '456 Street, Singapore', 'HR', 'Workplace Safety', 'Canadian', 'None', 'lancelot', '123', 'HR');

INSERT dbo.CONTRACT
VALUES(4000, 'Free Healthcare', '14 Days Available', 'Every Year June', '20201010', 1)

INSERT dbo.CONTRACT
VALUES(3000, 'Free Healthcare, Discount On Items', '7 Days Available', 'Not Applicable', '20201011', 2)

INSERT dbo.BANK_DETAIL
VALUES('OCBC', '654-123456', 'Pierre Gasly', 1)

INSERT dbo.BANK_DETAIL
VALUES('DBS', '654-789123', 'Lance Stroll', 2)

INSERT dbo.PAYROLL
VALUES(4000, 500, NULL, '20200505', 1, 1)

INSERT dbo.PAYROLL
VALUES(3000, 500, '20200506', '20200505', 1, 2)

INSERT dbo.ATTENDANCE
VALUES(1, '11/11/2020', 'Came to work', 'Not Applicable')

INSERT dbo.ATTENDANCE
VALUES(2, '11/11/2020', 'Did not come', 'Was Sick')

/* End of HR */

/* Start of Patient */
INSERT [dbo].[PATIENT] 
VALUES('John', 'Chua', 'S1122334D', '20020710', 'M', 'Singaporean', 'Singapore Citizen', '842357', 'Khathib Drive 16', NULL, NULL, '91234567', NULL, 'johnchua@gmail.com', '20201120', '20201229');

INSERT [dbo].[PATIENT] 
VALUES('Jasmine', 'Lim', 'S9876543D', '19980228', 'F', 'Singaporean', 'Permenant Resident', '465846', 'Lorong Street 33', NULL, NULL, '82345671', NULL, 'jasminelim@gmail.com', '20201221', '20201225');
/* End of Patient */

/* start of Feedback */
INSERT [dbo].[FEEDBACK]
VALUES ('Good service!', 'John Chua', 'johnchua@gmail.com', '91234567', 0, 1)

INSERT [dbo].[FEEDBACK]
VALUES ('Lousy service! I faced a long waiting time.', 'Jamine Lim', 'jasminelim@gmail.com', '82345671', 0, 2)
/* end of Feedback */

/* start of Feedback */
INSERT [dbo].[MEDICAL_APPOINTMENT_RECORD]
VALUES ('12:35:00', '20201120', NULL, 'Room 501', 1)

INSERT [dbo].[MEDICAL_APPOINTMENT_RECORD]
VALUES ('16:30:00', '20201221', NULL, 'Room 301', 2)
/* end of Feedback */

/* start of Doctor */
INSERT [dbo].[EMPLOYEE]
VALUES ('S7744556D', 'Edward', 'Jenner', 'edwardjenner@gmail.com', '19900102', 'M', '456 Yishun Street, Singapore', 'Doctor', 'Internal Medicine Doctor', 'American', 'None', 'edwardjenner', '123', 'Emergency Management');


INSERT [dbo].[EMPLOYEE]
VALUES ('S3434345D', 'Federick', 'Banting', 'federickbanting@gmail.com', '19800501', 'M', '456 Katong Street, Singapore', 'Doctor', 'Internal Medicine Doctor', 'Canadian', 'None', 'federickbanting', '123', 'Pain Management');
/* end of Doctor */

/* 3 and 4 are doctor */
/* Start of Equipment Service */
INSERT [dbo].[EQUIPMENT_SERVICE_RECORD]
VALUES ('Defibrillators', '3958304', 'Room 501', 'Unable to start up, might be due to lack of faulty cable', 3);

INSERT [dbo].[EQUIPMENT_SERVICE_RECORD]
VALUES ('Anesthesia Machine', '47823943', 'Room 601', 'Screen damage, unable to see the content on the screen', 4);
/* End of Equipment Service */


/* Start of Lab Service */
INSERT [dbo].[LAB_SERVICE_RECORD] 
VALUES (2, 'Blood Test', NULL, 3);

INSERT [dbo].[LAB_SERVICE_RECORD] 
VALUES (4, 'Urine Test', NULL, 4);
/* End of Lab Service */

/* Start of Medical Record */
INSERT [dbo].[MEDICAL_RECORD] 
VALUES ('90/120', '18', '37', '80', 'Fabry Disease', 'agalsidase-alpha', '20200630', 'painkiller', NULL, 1, 3);

INSERT [dbo].[MEDICAL_RECORD] 
VALUES ('90/120', '18', '37', '80', 'Fabry Disease', 'agalsidase-alpha', '20200524', 'painkiller', NULL, 2, 4);
/* End of Medical Record */

/* Start of Role */
INSERT [dbo].[ROLE] 
VALUES ('Doctor');

INSERT [dbo].[ROLE]
VALUES ('HR');
/* End of Role */

/* Start of Resource */
INSERT [dbo].[RESOURCE] 
VALUES ('Patient_Database');

INSERT [dbo].[RESOURCE]
VALUES ('Employee_Database');
/* End of Resource */

/* Start of Role Permission */
INSERT [dbo].[ROLE_PERMISSION]
VALUES (1, 1, 1, 1, 0, 1);

INSERT [dbo].[ROLE_PERMISSION]
VALUES (2, 2, 1, 1, 0, 1);
/* End of Role Permission */

