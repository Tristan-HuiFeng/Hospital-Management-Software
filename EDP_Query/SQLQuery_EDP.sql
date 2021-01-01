CREATE TABLE [dbo].[PATIENT] (
    [Patient_ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Login_ID]        NVARCHAR (64)  NOT NULL,
    [Password]        NVARCHAR (64)  NOT NULL,
    [First_Name]      NVARCHAR (64)  NOT NULL,
    [Last_Name]       NVARCHAR (64)  NOT NULL,
    [NRIC]            NCHAR (9)      NOT NULL,
    [DOB]             DATE           NOT NULL,
    [Age]             TINYINT        NOT NULL,
    [Sex]             NCHAR (1)      NOT NULL,
    [Nationality]     NVARCHAR (64)  NOT NULL,
    [Citizenship]     NVARCHAR (64)  NOT NULL,
    [Postal_Code]     NVARCHAR (10)  NOT NULL,
    [Address]         NVARCHAR (64)  NOT NULL,
    [Allergies]       NVARCHAR (MAX) NULL,
    [Medical_History] NVARCHAR (MAX) NULL,
    [Phone_Number]    NVARCHAR (32)  NOT NULL,
    [Home_Number]     NVARCHAR (32)  NULL,
    [Email]           NVARCHAR (32)  NOT NULL,
    [Created_Date]    DATETIME       NOT NULL,
    [Update_Date]     DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Patient_ID] ASC)
);

CREATE TABLE [dbo].[MEDICAL_APPOINTMENT_RECORD] (
    [Appoint_ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Appointment_Time] TIME (7)       NOT NULL,
    [Appoinment_Date]  DATE           NOT NULL,
    [Comments]         NVARCHAR (MAX) NULL,
    [Location]         NVARCHAR (MAX) NOT NULL,
    [Patient_ID]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Appoint_ID] ASC),
    CONSTRAINT [FK_Patient_ID_Appointment] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[PATIENT] ([Patient_ID])
);

CREATE TABLE [dbo].[FEEDBACK] (
    [Feedback_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Feedback]        VARCHAR (MAX) NOT NULL,
    [Name]            VARCHAR (64)  NULL,
    [Email]           NVARCHAR (32) NULL,
    [Mobile Number]   VARCHAR (64)  NULL,
    [Further_Contact] BIT           NULL,
    [Patient_ID]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Feedback_ID] ASC),
    CONSTRAINT [FK_Patient_ID_Feedback] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[PATIENT] ([Patient_ID])
);

CREATE TABLE [dbo].[EMPLOYEE] (
    [Employee_ID]        INT            IDENTITY (1, 1) NOT NULL,
    [NRIC]               NCHAR (9)      NOT NULL,
    [First_Name]         NVARCHAR (64)  NOT NULL,
    [Last_Name]          NVARCHAR (64)  NOT NULL,
    [Email]              NVARCHAR (32)  NOT NULL,
    [DOB]                DATE           NOT NULL,
    [Sex]                NCHAR (1)      NOT NULL,
    [Address]            NVARCHAR (64)  NOT NULL,
    [Department]         NVARCHAR (64)  NOT NULL,
    [Position]           NVARCHAR (64)  NOT NULL,
    [Nationality]        NVARCHAR (64)  NOT NULL,
    [Health_Declaration] NVARCHAR (MAX) NULL,
    [Login_ID]           NVARCHAR (64)  NOT NULL,
    [Password]           NVARCHAR (64)  NOT NULL,
    [Job_Function]       NVARCHAR (64)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Employee_ID] ASC)
);

CREATE TABLE [dbo].[MEDICAL_RECORD] (
    [Medical_Record_ID] INT            IDENTITY (1, 1) NOT NULL,
    [Blood_Pressure]    NVARCHAR (32)  NOT NULL,
    [Respiration_Rate]  NVARCHAR (32)  NOT NULL,
    [Body_Temperature]  NVARCHAR (32)  NOT NULL,
    [Pulse_Rate]        NVARCHAR (32)  NOT NULL,
    [Diagnosis]         NVARCHAR (MAX) NOT NULL,
    [Treatment]         NVARCHAR (MAX) NOT NULL,
    [Date]              DATETIME       NOT NULL,
    [Prescriptions]     NVARCHAR (MAX) NOT NULL,
    [Remarks]           NVARCHAR (MAX) NOT NULL,
    [Patient_ID]        INT            NOT NULL,
    [Employee_ID]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Medical_Record_ID] ASC),
    CONSTRAINT [FK_Patient_ID_Medical] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[PATIENT] ([Patient_ID]),
    CONSTRAINT [FK_Employee_ID_Medical] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[EMPLOYEE] ([Employee_ID])
);

CREATE TABLE [dbo].[EQUIPMENT_SERVICE_RECORD] (
    [Equipment_Service_ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Equipment_Name]          NVARCHAR (64) NOT NULL,
    [Equipment_Serial_Number] NVARCHAR (64) NOT NULL,
    [Location]                VARCHAR (MAX) NOT NULL,
    [Description]             VARCHAR (MAX) NOT NULL,
    [Employee_ID]             INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Equipment_Service_ID] ASC),
    CONSTRAINT [FK_Employee_ID_Equipment] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[EMPLOYEE] ([Employee_ID])
);

CREATE TABLE [dbo].[LAB_SERVICE_RECORD] (
    [Lab_Service_ID] INT            IDENTITY (1, 1) NOT NULL,
    [Priority]       TINYINT        NOT NULL,
    [Test_Required]  NVARCHAR (MAX) NOT NULL,
    [Remarks]        NVARCHAR (MAX) NULL,
    [Employee_ID]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Lab_Service_ID] ASC),
    CONSTRAINT [FK_Employee_ID_Lab] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[EMPLOYEE] ([Employee_ID])
);

CREATE TABLE [dbo].[BANK_DETAIL] (
    [Bank_Detail_ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Bank_Name]           NVARCHAR (64) NOT NULL,
    [Bank_Account_Number] NVARCHAR (64) NOT NULL,
    [Bank_Holder_Name]    NVARCHAR (64) NOT NULL,
    [Employee_ID]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Bank_Detail_ID] ASC),
    CONSTRAINT [FK_Employee_ID_Bank] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[EMPLOYEE] ([Employee_ID])
);

CREATE TABLE [dbo].[ATTENDANCE] (
    [Employee_ID] INT            NOT NULL,
    [Date]        DATE           NOT NULL,
    [Status]      NVARCHAR (64)  NOT NULL,
    [Reason]      NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Employee_ID] ASC, [Date] ASC),
    CONSTRAINT [FK_Employee_ID_Attendance] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[EMPLOYEE] ([Employee_ID])
);

CREATE TABLE [dbo].[CONTRACT] (
    [Contract_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Salary]      MONEY         NOT NULL,
    [Benefits]    NVARCHAR (64) NOT NULL,
    [Holidays]    NVARCHAR (64) NOT NULL,
    [Vacation]    NVARCHAR (64) NOT NULL,
    [Create_Date] DATETIME      NOT NULL,
    [Employee_ID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Contract_ID] ASC),
    CONSTRAINT [FK_Employee_ID_Contract] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[EMPLOYEE] ([Employee_ID])
);

CREATE TABLE [dbo].[PAYROLL] (
    [Payroll_ID]     INT      IDENTITY (1, 1) NOT NULL,
    [Salary]         MONEY    NOT NULL,
    [Bonus_Amount]   MONEY    NOT NULL,
    [Processed_Date] DATETIME NULL,
    [Created_Date]   DATETIME NOT NULL,
    [Employee_ID]    INT      NOT NULL,
    [Bank_Detail_ID] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Payroll_ID] ASC),
    CONSTRAINT [FK_Employee_ID_Payroll] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[EMPLOYEE] ([Employee_ID]),
    CONSTRAINT [FK_Bank_ID_Payroll] FOREIGN KEY ([Bank_Detail_ID]) REFERENCES [dbo].[BANK_DETAIL] ([Bank_Detail_ID])
);

CREATE TABLE [dbo].[ROLE] (
    [Role_ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Role_Name] VARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([Role_ID] ASC)
);

CREATE TABLE [dbo].[ROLE_PERMISSION] (
    [Resource_ID] INT NOT NULL,
    [Role_ID]     INT NOT NULL,
    [View]        BIT NOT NULL,
    [Add]         BIT NOT NULL,
    [Edit]        BIT NOT NULL,
    [Delete]      BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Role_ID] ASC, [Resource_ID] ASC),
    CONSTRAINT [FK_Recource_ID_Permission] FOREIGN KEY ([Resource_ID]) REFERENCES [dbo].[RESOURCE] ([Resource_ID]),
    CONSTRAINT [FK_Role_ID_Permission] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[ROLE] ([Role_ID])
);

CREATE TABLE [dbo].[RESOURCE] (
    [Resource_ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Resource_Name] VARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([Resource_ID] ASC)
);