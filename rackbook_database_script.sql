CREATE DATABASE Rackbook
GO

USE Rackbook
GO

/****** Object:  Table [dbo].[AccountDetail]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountDetail](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[AccountNumber] [nvarchar](20) NOT NULL,
	[AccountName] [nvarchar](250) NOT NULL,
	[AccountDescription] [nvarchar](max) NULL,
	[AccountParentID] [int] NULL,
	[AccountTypeID] [int] NOT NULL,
	[AccountStatementTypeID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[CreatedDateAt] [datetime] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[UpdatedDateAt] [datetime] NULL,
 CONSTRAINT [PK_AccountDetail] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[AccountTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AccountTypeName] [nvarchar](50) NOT NULL,
	[AccountTypeDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyTypeID] [int] NOT NULL,
	[CompanyName] [nvarchar](250) NOT NULL,
	[EmployerIdentificationNo] [nvarchar](20) NULL,
	[TaxIdentificationNo] [nvarchar](20) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](250) NULL,
	[Website] [nvarchar](250) NULL,
	[AddressLine1] [nvarchar](150) NULL,
	[AddressLine2] [nvarchar](150) NULL,
	[CountryID] [int] NULL,
	[ProvinceID] [int] NULL,
	[ZipCode] [nvarchar](10) NULL,
	[CityName] [nvarchar](150) NULL,
	[CompanyLogo] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyType]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyType](
	[CompanyTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CompanyType] PRIMARY KEY CLUSTERED 
(
	[CompanyTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [nvarchar](3) NOT NULL,
	[CountryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CustomerTypeID] [int] NOT NULL,
	[CustomerCode] [nvarchar](20) NOT NULL,
	[CustomerName] [nvarchar](150) NOT NULL,
	[CR_Number] [nvarchar](20) NULL,
	[VAT_Number] [nvarchar](20) NULL,
	[Phone] [nvarchar](20) NULL,
	[Fax] [nvarchar](20) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Email] [nvarchar](250) NULL,
	[AccountID] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[CreatedDateAt] [datetime] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[UpdatedDateAt] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomersAddress]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersAddress](
	[CustomerAddressID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[BillingAddressLine1] [nvarchar](50) NULL,
	[BillingAddressLine2] [nvarchar](50) NULL,
	[BillingCountryID] [int] NULL,
	[BillingProvinceID] [int] NULL,
	[BillingZipCode] [nvarchar](10) NULL,
	[BillingCityName] [nvarchar](150) NULL,
	[ShippingAddressLine1] [nvarchar](50) NULL,
	[ShippingAddressLine2] [nvarchar](50) NULL,
	[ShippingCountryID] [int] NULL,
	[ShippingProvinceID] [int] NULL,
	[ShippingZipCode] [nvarchar](10) NULL,
	[ShippingCityName] [nvarchar](150) NULL,
 CONSTRAINT [PK_CustomersAddress] PRIMARY KEY CLUSTERED 
(
	[CustomerAddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemGroup](
	[ItemGroupID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ItemGroupName] [nvarchar](50) NOT NULL,
	[ItemGroupDescription] [nvarchar](350) NULL,
	[SortOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ItemGroup] PRIMARY KEY CLUSTERED 
(
	[ItemGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ItemGroupID] [int] NOT NULL,
	[ItemTypeID] [int] NOT NULL,
	[ItemCode] [nvarchar](50) NOT NULL,
	[ItemName] [nvarchar](100) NOT NULL,
	[ItemDescription] [nvarchar](350) NULL,
	[UPC] [nvarchar](30) NULL,
	[EAN] [nvarchar](30) NULL,
	[ISBN] [nvarchar](30) NULL,
	[Color] [nvarchar](30) NULL,
	[ItemUnitID] [int] NOT NULL,
	[PackQuantity] [float] NOT NULL,
	[ItemWeight] [float] NULL,
	[IsInwardTax] [bit] NOT NULL,
	[ItemInwardTaxID] [int] NOT NULL,
	[IsOutwardTax] [bit] NOT NULL,
	[ItemOutwardTaxID] [int] NOT NULL,
	[PurchaseUnitPrice] [decimal](18, 2) NOT NULL,
	[CostUnitPrice] [decimal](18, 2) NOT NULL,
	[SellingUnitPrice] [decimal](18, 2) NOT NULL,
	[PurchaseAccountID] [int] NULL,
	[CGSAccountID] [int] NULL,
	[SaleAccountID] [int] NULL,
	[ReorderQuantity] [float] NULL,
	[ItemLogo] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[CreatedDateAt] [datetime] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[UpdatedDateAt] [datetime] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemUnit]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemUnit](
	[ItemUnitID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ItemUnitName] [nvarchar](50) NOT NULL,
	[ItemUnitDescription] [nvarchar](350) NULL,
	[SortOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ItemUnit] PRIMARY KEY CLUSTERED 
(
	[ItemUnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JournalEntry]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalEntry](
	[JournalEntryID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[JournalEntryTypeID] [int] NOT NULL,
	[JournalEntryDate] [datetime] NOT NULL,
	[JournalEntryNumber] [nvarchar](50) NOT NULL,
	[AccountID] [int] NULL,
	[Remarks] [nvarchar](max) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[SourcePath] [nvarchar](250) NOT NULL,
	[ReferenceID] [int] NULL,
	[JournalEntryStatusID] [int] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[CreatedDateAt] [datetime] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[UpdatedDateAt] [datetime] NULL,
	[AuthorizedUserID] [int] NULL,
	[AuthorizedDateAt] [datetime] NULL,
 CONSTRAINT [PK_JournalEntry] PRIMARY KEY CLUSTERED 
(
	[JournalEntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JournalEntryDetail]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalEntryDetail](
	[JournalEntryDetailID] [int] IDENTITY(1,1) NOT NULL,
	[JournalEntryID] [int] NOT NULL,
	[AccountID] [int] NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[Debit_Amount] [decimal](18, 2) NOT NULL,
	[Credit_Amount] [decimal](18, 2) NOT NULL,
	[IsReconciled] [bit] NULL,
	[Entry_Number] [int] NULL,
 CONSTRAINT [PK_JournalEntryDetail] PRIMARY KEY CLUSTERED 
(
	[JournalEntryDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JournalEntryType]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalEntryType](
	[JournalEntryTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[JournalEntryTypeName] [nvarchar](50) NOT NULL,
	[JournalentryTypeDescription] [nvarchar](350) NULL,
	[IsActive] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_JournalEntryType] PRIMARY KEY CLUSTERED 
(
	[JournalEntryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NavigationItem]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NavigationItem](
	[NavigationItemID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[NavigationItemName] [nvarchar](50) NOT NULL,
	[NavigationItemIcon] [nvarchar](50) NULL,
	[NavigationItemPath] [nvarchar](500) NULL,
	[NavigationItemTitle] [nvarchar](max) NULL,
	[NavigationItemDescription] [nvarchar](max) NULL,
	[ParentNavigationItemID] [int] NULL,
	[SortOrder] [int] NULL,
	[IsNew] [bit] NULL,
	[IsUpdate] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedUserID] [int] NULL,
	[CreatedDateAt] [datetime] NULL,
	[UpdatedUserID] [int] NULL,
	[UpdatedDateAt] [datetime] NULL,
 CONSTRAINT [PK_NavigationItem] PRIMARY KEY CLUSTERED 
(
	[NavigationItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[ProvinceID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[ProvinceCode] [nvarchar](5) NULL,
	[ProvinceName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[ProvinceID] ASC,
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleOrderDetail]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleOrderDetail](
	[SaleOrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[SaleOrderID] [int] NULL,
	[ItemID] [int] NULL,
	[Quantity] [decimal](18, 2) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SaleOrderDetail] PRIMARY KEY CLUSTERED 
(
	[SaleOrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleOrderMaster]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleOrderMaster](
	[SaleOrderID] [int] IDENTITY(1,1) NOT NULL,
	[SaleOrderDate] [datetime] NULL,
	[SaleOrderNumber] [nvarchar](20) NULL,
	[CustomerId] [int] NULL,
	[SalePerson] [nvarchar](150) NULL,
	[Remarks] [nvarchar](350) NULL,
	[Terms_And_Condition] [nvarchar](max) NULL,
	[TotalQuantity] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[CreatedUserID] [int] NULL,
	[CreatedDateAt] [datetime] NULL,
	[UpdatedUserID] [int] NULL,
	[UpdatedDateAt] [datetime] NULL,
 CONSTRAINT [PK_SaleOrderMaster] PRIMARY KEY CLUSTERED 
(
	[SaleOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[UserRoleName] [nvarchar](50) NOT NULL,
	[UserRoleDescription] [nvarchar](350) NULL,
	[IsActive] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[UserRoleID] [int] NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](20) NULL,
	[Email] [nvarchar](250) NULL,
	[Password] [nvarchar](50) NOT NULL,
	[PasswordExpired] [datetime] NULL,
	[OTP] [nvarchar](5) NULL,
	[OTPExpired] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_AccountDetail]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_AccountDetail]
AS
SELECT        dbo.AccountDetail.AccountID, dbo.AccountDetail.CompanyID, dbo.AccountDetail.AccountNumber, dbo.AccountDetail.AccountName, dbo.AccountDetail.AccountDescription, dbo.AccountDetail.AccountParentID, 
                         dbo.AccountDetail.AccountTypeID, dbo.AccountType.AccountTypeName, dbo.AccountType.AccountTypeDescription, dbo.AccountDetail.AccountStatementTypeID, dbo.AccountDetail.IsActive, 
                         dbo.AccountDetail.CreatedUserID, dbo.AccountDetail.CreatedDateAt, dbo.AccountDetail.UpdatedUserID, dbo.AccountDetail.UpdatedDateAt
FROM            dbo.AccountDetail INNER JOIN
                         dbo.AccountType ON dbo.AccountDetail.AccountTypeID = dbo.AccountType.AccountTypeID
GO
/****** Object:  View [dbo].[vw_Accounts]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_Accounts]
AS
SELECT        dbo.AccountDetail.AccountID, dbo.AccountDetail.CompanyID, dbo.AccountDetail.AccountNumber, dbo.AccountDetail.AccountName, dbo.AccountDetail.AccountDescription, dbo.AccountDetail.AccountParentID, 
                         dbo.AccountDetail.AccountTypeID, dbo.AccountType.AccountTypeName, dbo.AccountType.AccountTypeDescription, dbo.AccountDetail.AccountStatementTypeID, dbo.AccountDetail.IsActive, 
                         dbo.AccountDetail.CreatedUserID, dbo.AccountDetail.CreatedDateAt, dbo.AccountDetail.UpdatedUserID, dbo.AccountDetail.UpdatedDateAt
FROM            dbo.AccountDetail INNER JOIN
                         dbo.AccountType ON dbo.AccountDetail.AccountTypeID = dbo.AccountType.AccountTypeID
WHERE        (dbo.AccountDetail.AccountID <> dbo.AccountDetail.AccountParentID)
GO
/****** Object:  View [dbo].[vw_Items]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_Items]
AS
SELECT        dbo.Items.ItemID, dbo.Items.CompanyID, dbo.Items.ItemGroupID, dbo.ItemGroup.ItemGroupName, dbo.ItemGroup.ItemGroupDescription, dbo.Items.ItemTypeID, 
                         CASE WHEN dbo.Items.ItemTypeID = 1 THEN 'Goods' WHEN dbo.Items.ItemTypeID = 2 THEN 'Service' END AS ItemTypeName, dbo.Items.ItemCode, dbo.Items.ItemName, dbo.Items.ItemDescription, dbo.Items.UPC, 
                         dbo.Items.EAN, dbo.Items.ISBN, dbo.Items.Color, dbo.Items.ItemUnitID, dbo.ItemUnit.ItemUnitName, dbo.ItemUnit.ItemUnitDescription, dbo.Items.PackQuantity, dbo.Items.ItemWeight, 
                         dbo.Items.IsInwardTax, dbo.Items.ItemInwardTaxID, dbo.Items.IsOutwardTax, dbo.Items.ItemOutwardTaxID,dbo.Items.PurchaseUnitPrice, 
                         dbo.Items.CostUnitPrice, dbo.Items.SellingUnitPrice, dbo.Items.PurchaseAccountID, dbo.Items.CGSAccountID, dbo.Items.SaleAccountID, dbo.Items.ReorderQuantity, dbo.Items.ItemLogo, dbo.Items.IsActive, 
                         dbo.Items.CreatedUserID, dbo.Items.CreatedDateAt, dbo.Items.UpdatedUserID, dbo.Items.UpdatedDateAt
FROM            dbo.Items INNER JOIN
                         dbo.ItemGroup ON dbo.Items.ItemGroupID = dbo.ItemGroup.ItemGroupID INNER JOIN
                         dbo.ItemUnit ON dbo.Items.ItemUnitID = dbo.ItemUnit.ItemUnitID
GO
/****** Object:  View [dbo].[vw_Users]    Script Date: 29/12/2024 10:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Users]
AS

SELECT        Users.UserID, Users.CompanyID, Company.CompanyTypeID, CompanyType.CompanyTypeName, Company.CompanyName, Company.EmployerIdentificationNo, Company.TaxIdentificationNo, Users.UserRoleID, 
                         UserRole.UserRoleName, UserRole.UserRoleDescription, Users.FullName, Users.UserName, Users.Mobile, Users.Email, Users.Password, Users.PasswordExpired, Users.OTP, Users.OTPExpired, Users.IsActive
FROM            Users INNER JOIN
                         UserRole ON Users.UserRoleID = UserRole.UserRoleID INNER JOIN
                         Company ON Users.CompanyID = Company.CompanyID INNER JOIN
                         CompanyType ON Company.CompanyTypeID = CompanyType.CompanyTypeID
GO
SET IDENTITY_INSERT [dbo].[AccountDetail] ON 

INSERT [dbo].[AccountDetail] ([AccountID], [CompanyID], [AccountNumber], [AccountName], [AccountDescription], [AccountParentID], [AccountTypeID], [AccountStatementTypeID], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (3, 1, N'10000', N'Current Assets', N'Current Assets', NULL, 1, 1, 1, 1, CAST(N'2024-10-14T15:01:18.187' AS DateTime), 1, CAST(N'2024-10-14T15:29:58.853' AS DateTime))
SET IDENTITY_INSERT [dbo].[AccountDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeDescription]) VALUES (1, N'Assets', N'Resources owned by the entity')
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeDescription]) VALUES (2, N'Liabilities', N'Obligations of the entity')
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeDescription]) VALUES (3, N'Equity', N'Owner’s residual interest in the entity')
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeDescription]) VALUES (4, N'Revenue', N'Income generated from operations')
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeDescription]) VALUES (5, N'Expenses', N'Costs incurred to generate revenue')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyID], [CompanyTypeID], [CompanyName], [EmployerIdentificationNo], [TaxIdentificationNo], [Phone], [Email], [Website], [AddressLine1], [AddressLine2], [CountryID], [ProvinceID], [ZipCode], [CityName], [CompanyLogo], [IsActive], [CreatedDate]) VALUES (1, 1, N'XYZ Company', N'123', N'123', N'0503186175', N'se.imranali@gmail.com', N'www.google.com', N'-', N'-', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2024-09-29T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyType] ON 

INSERT [dbo].[CompanyType] ([CompanyTypeID], [CompanyTypeName]) VALUES (4, N'Consultancy')
INSERT [dbo].[CompanyType] ([CompanyTypeID], [CompanyTypeName]) VALUES (3, N'ICT Service')
INSERT [dbo].[CompanyType] ([CompanyTypeID], [CompanyTypeName]) VALUES (2, N'Retail & Wholesale')
INSERT [dbo].[CompanyType] ([CompanyTypeID], [CompanyTypeName]) VALUES (1, N'Services')
SET IDENTITY_INSERT [dbo].[CompanyType] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [CountryCode], [CountryName]) VALUES (3, N'IND', N'India')
INSERT [dbo].[Country] ([CountryID], [CountryCode], [CountryName]) VALUES (2, N'KSA', N'Saudi Arabia')
INSERT [dbo].[Country] ([CountryID], [CountryCode], [CountryName]) VALUES (1, N'PAK', N'Pakistan')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [CompanyID], [CustomerTypeID], [CustomerCode], [CustomerName], [CR_Number], [VAT_Number], [Phone], [Fax], [Mobile], [Email], [AccountID], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1, 1, 2, N'CR2001', N'Waheed Shahid', N'123', N'4555', N'14545', NULL, N'03039889987', N'se.imranali@gmail.com', NULL, 1, 1, CAST(N'2024-11-12T16:15:50.417' AS DateTime), 1, CAST(N'2024-11-13T06:39:37.493' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomersAddress] ON 

INSERT [dbo].[CustomersAddress] ([CustomerAddressID], [CustomerID], [BillingAddressLine1], [BillingAddressLine2], [BillingCountryID], [BillingProvinceID], [BillingZipCode], [BillingCityName], [ShippingAddressLine1], [ShippingAddressLine2], [ShippingCountryID], [ShippingProvinceID], [ShippingZipCode], [ShippingCityName]) VALUES (1, 1, N'asdfasdf', N'asdfasdf', 1, 1, N'3900', N'Muridke', N'test', N'teasd', 1, 1, N'39000', N'Muridke')
SET IDENTITY_INSERT [dbo].[CustomersAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemGroup] ON 

INSERT [dbo].[ItemGroup] ([ItemGroupID], [CompanyID], [ItemGroupName], [ItemGroupDescription], [SortOrder], [IsActive]) VALUES (1016, 1, N'Avaya', N'Avya', 1, 1)
INSERT [dbo].[ItemGroup] ([ItemGroupID], [CompanyID], [ItemGroupName], [ItemGroupDescription], [SortOrder], [IsActive]) VALUES (1017, 1, N'Software', N'Software', 1, 0)
SET IDENTITY_INSERT [dbo].[ItemGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([ItemID], [CompanyID], [ItemGroupID], [ItemTypeID], [ItemCode], [ItemName], [ItemDescription], [UPC], [EAN], [ISBN], [Color], [ItemUnitID], [PackQuantity], [ItemWeight], [IsInwardTax], [ItemInwardTaxID], [IsOutwardTax], [ItemOutwardTaxID], [PurchaseUnitPrice], [CostUnitPrice], [SellingUnitPrice], [PurchaseAccountID], [CGSAccountID], [SaleAccountID], [ReorderQuantity], [ItemLogo], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (4, 1, 1017, 1, N'SFT1001', N'ERP Enterprise', N'ERP System', NULL, NULL, NULL, NULL, 5, 1, NULL, 1, 1, 1, 1, CAST(2000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, 1, 1, CAST(N'2024-10-13T20:26:22.457' AS DateTime), 1, CAST(N'2024-10-13T20:27:48.207' AS DateTime))
INSERT [dbo].[Items] ([ItemID], [CompanyID], [ItemGroupID], [ItemTypeID], [ItemCode], [ItemName], [ItemDescription], [UPC], [EAN], [ISBN], [Color], [ItemUnitID], [PackQuantity], [ItemWeight], [IsInwardTax], [ItemInwardTaxID], [IsOutwardTax], [ItemOutwardTaxID], [PurchaseUnitPrice], [CostUnitPrice], [SellingUnitPrice], [PurchaseAccountID], [CGSAccountID], [SaleAccountID], [ReorderQuantity], [ItemLogo], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (5, 1, 1017, 1, N'T0900', N'ABC Item', N'ABC item', NULL, NULL, NULL, NULL, 5, 100, 90, 0, 1, 0, 1, CAST(100.00 AS Decimal(18, 2)), CAST(103.00 AS Decimal(18, 2)), CAST(130.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, 0, 1, CAST(N'2024-11-13T23:46:45.237' AS DateTime), NULL, NULL)
INSERT [dbo].[Items] ([ItemID], [CompanyID], [ItemGroupID], [ItemTypeID], [ItemCode], [ItemName], [ItemDescription], [UPC], [EAN], [ISBN], [Color], [ItemUnitID], [PackQuantity], [ItemWeight], [IsInwardTax], [ItemInwardTaxID], [IsOutwardTax], [ItemOutwardTaxID], [PurchaseUnitPrice], [CostUnitPrice], [SellingUnitPrice], [PurchaseAccountID], [CGSAccountID], [SaleAccountID], [ReorderQuantity], [ItemLogo], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (6, 1, 1017, 1, N'T0809', N'XYZ Item', N'XYZ Item', NULL, NULL, NULL, NULL, 5, 100, 9, 0, 1, 0, 1, CAST(150.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, 1, 1, CAST(N'2024-11-13T23:47:37.510' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemUnit] ON 

INSERT [dbo].[ItemUnit] ([ItemUnitID], [CompanyID], [ItemUnitName], [ItemUnitDescription], [SortOrder], [IsActive]) VALUES (2, 1, N'Kg', N'Killogram', 1, 1)
INSERT [dbo].[ItemUnit] ([ItemUnitID], [CompanyID], [ItemUnitName], [ItemUnitDescription], [SortOrder], [IsActive]) VALUES (3, 1, N'Gm', N'Gram', 1, 1)
INSERT [dbo].[ItemUnit] ([ItemUnitID], [CompanyID], [ItemUnitName], [ItemUnitDescription], [SortOrder], [IsActive]) VALUES (4, 1, N'Pcs', N'Piece ', 1, 1)
INSERT [dbo].[ItemUnit] ([ItemUnitID], [CompanyID], [ItemUnitName], [ItemUnitDescription], [SortOrder], [IsActive]) VALUES (5, 1, N'Unit', N'Each', 1, 1)
INSERT [dbo].[ItemUnit] ([ItemUnitID], [CompanyID], [ItemUnitName], [ItemUnitDescription], [SortOrder], [IsActive]) VALUES (6, 1, N'Box', N'Box', 1, 1)
SET IDENTITY_INSERT [dbo].[ItemUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[JournalEntryType] ON 

INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (1, 1, N'JV', N'Journal Voucher', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (2, 1, N'CPV', N'Cash Payment Voucher', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (3, 1, N'BPV', N'Bank Payment Voucher', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (4, 1, N'BRV', N'Bank Receipt Voucher', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (5, 1, N'CRV', N'Cash Receipt Voucher', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (6, 1, N'SI', N'Sale Invoice', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (7, 1, N'SR', N'Sale Return Invoice', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (8, 1, N'PI', N'Purchase Invoice', 1, 1)
INSERT [dbo].[JournalEntryType] ([JournalEntryTypeID], [CompanyID], [JournalEntryTypeName], [JournalentryTypeDescription], [IsActive], [SortOrder]) VALUES (9, 1, N'PR', N'Purchase Return Invoice', 1, 1)
SET IDENTITY_INSERT [dbo].[JournalEntryType] OFF
GO
SET IDENTITY_INSERT [dbo].[NavigationItem] ON 

INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1, 1, N'Home', N'dashboard', N'/', N'Home', N'Home', NULL, 1, 0, 0, 1, 1, CAST(N'2024-10-15T10:57:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (2, 1, N'Finance & Accounts', N'finance', NULL, N'Finance & Accounts', N'Finance & Accounts', NULL, 1, 0, 0, 1, 1, CAST(N'2024-10-15T10:59:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (3, 1, N'Journal Entry', NULL, N'journalentry', N'Journal Entry', N'Journal Entry', 2, 1, 0, 0, 1, 1, CAST(N'2024-10-15T11:35:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1003, 1, N'Chart of Accounts', N'account_tree', NULL, N'Chart of Accounts', N'Chart of Accounts', 2, 2, 0, 0, 1, 1, CAST(N'2024-11-10T12:59:59.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1004, 1, N'Main Accounts', NULL, N'mainaccounts', N'Main Accounts', N'Main Accounts', 1003, 1, 0, 0, 1, 1, CAST(N'2024-11-10T12:33:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1005, 1, N'Detail Accounts', NULL, N'detailaccounts', N'Detail Accounts', N'Detail Accounts', 1003, 2, 0, 0, 1, 1, CAST(N'2024-11-10T12:34:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1006, 1, N'Chart of Accounts Print', NULL, N'chartofaccounts', N'Chart of Accounts Print', N'Chart of Accounts Print', 1003, 3, 1, 0, 1, 1, CAST(N'2024-11-10T12:38:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1007, 1, N'Sales', N'shopping_cart', NULL, N'Sales', N'Sales', NULL, 3, 0, 0, 1, 1, CAST(N'2024-11-10T12:41:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1008, 1, N'Sale Invoice', NULL, N'saleinvoice', N'Sale Invoice', N'Sale Invoice', 1007, 1, 0, 0, 1, 1, CAST(N'2024-11-10T12:43:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1009, 1, N'Sale Return', NULL, N'salereturn', N'Sale Return', N'Sale Return', 1007, 2, 0, 0, 1, 1, CAST(N'2024-11-10T12:44:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1010, 1, N'Sale Order', NULL, N'saleorder', N'Sale Order', N'Sale Order', 1007, 3, 0, 0, 1, 1, CAST(N'2024-11-10T12:45:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1011, 1, N'Customers', NULL, N'customers', N'Customers', N'Customers', 1007, 4, 0, 0, 1, 1, CAST(N'2024-11-10T12:46:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1012, 1, N'Sale Reports', NULL, N'salereports', N'Sale Reports', N'Sale Reports', 1007, 5, 0, 0, 1, 1, CAST(N'2024-11-10T12:49:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1019, 1, N'Purchases', N'inventory_2', NULL, N'Purchases', N'Purchases', NULL, 4, 0, 0, 1, 1, CAST(N'2024-11-10T12:50:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1020, 1, N'Purchase Invoice', NULL, N'purchaseinvoice', N'Purchase Invoice', N'Purchase Invoice', 1019, 1, 0, 0, 1, 1, CAST(N'2024-11-10T12:51:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1022, 1, N'Purchase Return', NULL, N'purchasereturn', N'Purchase Return', N'Purchase Return', 1019, 2, 0, 0, 1, 1, CAST(N'2024-11-10T12:52:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1024, 1, N'Purchase Order', NULL, N'purchaseorder', N'Purchase Order', N'Purchase Order', 1019, 3, 0, 0, 1, 1, CAST(N'2024-11-10T12:53:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1025, 1, N'Vendors', NULL, N'vendors', N'Vendors', N'Vendors', 1019, 4, 0, 0, 1, 1, CAST(N'2024-11-10T12:55:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1026, 1, N'Purchase Reports', NULL, N'purchasereports', N'Purchase Reports', N'Purchase Reports', 1019, 5, 0, 0, 1, 1, CAST(N'2024-11-10T12:56:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1027, 1, N'Users Management', N'group', NULL, N'Users Management', N'Users Management', NULL, 5, 0, 0, 1, 1, CAST(N'2024-11-10T12:56:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1028, 1, N'Users', NULL, N'users', N'Users', N'Users', 1027, 1, 0, 0, 1, 1, CAST(N'2024-11-10T10:57:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1029, 1, N'Users Role', NULL, N'userrole', N'Users Role', N'Users Role', 1027, 2, 0, 0, 1, 1, CAST(N'2024-11-10T10:59:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1030, 1, N'Users Role Rights', NULL, N'userrolerights', N'Users Role Rights', N'Users Role Rights', 1027, 3, 0, 0, 1, 1, CAST(N'2024-11-10T13:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1031, 1, N'Setup', N'settings', NULL, N'Setup', N'Setup', NULL, 6, 0, 0, 1, 1, CAST(N'2024-11-10T13:17:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1032, 1, N'Inventory Management', N'inventory', NULL, N'Inventory Management', N'Inventory Management', 1031, 1, 0, 0, 1, 1, CAST(N'2024-11-10T13:17:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1033, 1, N'Items', NULL, N'items', N'Items', N'Items', 1031, 1, 0, 0, 1, 1, CAST(N'2024-11-10T13:18:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1034, 1, N'Items Group', NULL, N'itemgroup', N'Items Group', N'Items Group', 1031, 2, 0, 0, 1, 1, CAST(N'2024-11-10T13:19:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[NavigationItem] ([NavigationItemID], [CompanyID], [NavigationItemName], [NavigationItemIcon], [NavigationItemPath], [NavigationItemTitle], [NavigationItemDescription], [ParentNavigationItemID], [SortOrder], [IsNew], [IsUpdate], [IsActive], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1035, 1, N'Items Unit', NULL, N'itemunit', N'Items Unit', N'Items Unit', 1031, 3, 0, 0, 1, 1, CAST(N'2024-11-10T13:19:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[NavigationItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Province] ON 

INSERT [dbo].[Province] ([ProvinceID], [CountryID], [ProvinceCode], [ProvinceName]) VALUES (7, 1, N'AZK', N'Azad Kashmir')
INSERT [dbo].[Province] ([ProvinceID], [CountryID], [ProvinceCode], [ProvinceName]) VALUES (6, 1, N'BLC', N'Blochistan')
INSERT [dbo].[Province] ([ProvinceID], [CountryID], [ProvinceCode], [ProvinceName]) VALUES (8, 1, N'GB', N'Gilgit Baltistan')
INSERT [dbo].[Province] ([ProvinceID], [CountryID], [ProvinceCode], [ProvinceName]) VALUES (2, 1, N'KPK', N'Khayber Pakhtoona  Khawa')
INSERT [dbo].[Province] ([ProvinceID], [CountryID], [ProvinceCode], [ProvinceName]) VALUES (1, 1, N'PNB', N'Punjab')
INSERT [dbo].[Province] ([ProvinceID], [CountryID], [ProvinceCode], [ProvinceName]) VALUES (3, 1, N'SND', N'Sindh')
SET IDENTITY_INSERT [dbo].[Province] OFF
GO
SET IDENTITY_INSERT [dbo].[SaleOrderDetail] ON 

INSERT [dbo].[SaleOrderDetail] ([SaleOrderDetailID], [SaleOrderID], [ItemID], [Quantity], [UnitPrice], [TotalAmount]) VALUES (1, 0, 4, CAST(10.00 AS Decimal(18, 2)), CAST(760.00 AS Decimal(18, 2)), CAST(7600.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleOrderDetail] ([SaleOrderDetailID], [SaleOrderID], [ItemID], [Quantity], [UnitPrice], [TotalAmount]) VALUES (2, 0, 6, CAST(500.00 AS Decimal(18, 2)), CAST(9998.00 AS Decimal(18, 2)), CAST(4999000.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleOrderDetail] ([SaleOrderDetailID], [SaleOrderID], [ItemID], [Quantity], [UnitPrice], [TotalAmount]) VALUES (3, 0, 4, CAST(23.00 AS Decimal(18, 2)), CAST(98.00 AS Decimal(18, 2)), CAST(2254.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleOrderDetail] ([SaleOrderDetailID], [SaleOrderID], [ItemID], [Quantity], [UnitPrice], [TotalAmount]) VALUES (4, 0, 5, CAST(100.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(9000.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleOrderDetail] ([SaleOrderDetailID], [SaleOrderID], [ItemID], [Quantity], [UnitPrice], [TotalAmount]) VALUES (5, 0, 6, CAST(89.00 AS Decimal(18, 2)), CAST(977.00 AS Decimal(18, 2)), CAST(86953.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleOrderDetail] ([SaleOrderDetailID], [SaleOrderID], [ItemID], [Quantity], [UnitPrice], [TotalAmount]) VALUES (6, 0, 4, CAST(250.00 AS Decimal(18, 2)), CAST(87.00 AS Decimal(18, 2)), CAST(21750.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleOrderDetail] ([SaleOrderDetailID], [SaleOrderID], [ItemID], [Quantity], [UnitPrice], [TotalAmount]) VALUES (7, 0, 5, CAST(190.00 AS Decimal(18, 2)), CAST(89.00 AS Decimal(18, 2)), CAST(16910.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SaleOrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[SaleOrderMaster] ON 

INSERT [dbo].[SaleOrderMaster] ([SaleOrderID], [SaleOrderDate], [SaleOrderNumber], [CustomerId], [SalePerson], [Remarks], [Terms_And_Condition], [TotalQuantity], [TotalAmount], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (1, CAST(N'2024-11-14T00:00:00.000' AS DateTime), N'SO-10000', 1, N'Imran Ali', N'asd', N'asd', CAST(10.00 AS Decimal(18, 2)), CAST(7600.00 AS Decimal(18, 2)), 1, CAST(N'2024-11-14T02:37:45.563' AS DateTime), NULL, NULL)
INSERT [dbo].[SaleOrderMaster] ([SaleOrderID], [SaleOrderDate], [SaleOrderNumber], [CustomerId], [SalePerson], [Remarks], [Terms_And_Condition], [TotalQuantity], [TotalAmount], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (2, CAST(N'2024-11-14T00:00:00.000' AS DateTime), N'SO-00002', 1, N'f', N'sdf', N'asd', CAST(623.00 AS Decimal(18, 2)), CAST(5010254.00 AS Decimal(18, 2)), 1, CAST(N'2024-11-14T02:49:00.667' AS DateTime), NULL, NULL)
INSERT [dbo].[SaleOrderMaster] ([SaleOrderID], [SaleOrderDate], [SaleOrderNumber], [CustomerId], [SalePerson], [Remarks], [Terms_And_Condition], [TotalQuantity], [TotalAmount], [CreatedUserID], [CreatedDateAt], [UpdatedUserID], [UpdatedDateAt]) VALUES (3, CAST(N'2024-11-14T00:00:00.000' AS DateTime), N'SO-00003', 1, N'Imran Ali', N'Sale Orde ', N'Sale Order', CAST(529.00 AS Decimal(18, 2)), CAST(125613.00 AS Decimal(18, 2)), 1, CAST(N'2024-11-14T02:53:54.427' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[SaleOrderMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([UserRoleID], [CompanyID], [UserRoleName], [UserRoleDescription], [IsActive], [SortOrder]) VALUES (1, 1, N'SuperAdministrator', N'Super Administrator', 1, 1)
INSERT [dbo].[UserRole] ([UserRoleID], [CompanyID], [UserRoleName], [UserRoleDescription], [IsActive], [SortOrder]) VALUES (2, 1, N'Administrator', N'Administrator', 1, 1)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [CompanyID], [UserRoleID], [FullName], [UserName], [Mobile], [Email], [Password], [PasswordExpired], [OTP], [OTPExpired], [IsActive]) VALUES (1, 1, 1, N'Administrator', N'Admin', N'0503186175', N'se.imranali@gmail.com', N'123', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountDetail]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountDetail] ON [dbo].[AccountDetail]
(
	[CompanyID] ASC,
	[AccountNumber] ASC,
	[AccountName] ASC,
	[AccountParentID] ASC,
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_AccountName] ON [dbo].[AccountDetail]
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountNumber]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_AccountNumber] ON [dbo].[AccountDetail]
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountParentID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_AccountParentID] ON [dbo].[AccountDetail]
(
	[AccountParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountTypeID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_AccountTypeID] ON [dbo].[AccountDetail]
(
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Company]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Company] ON [dbo].[Company]
(
	[CompanyTypeID] ASC,
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CompanyEIN]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CompanyEIN] ON [dbo].[Company]
(
	[EmployerIdentificationNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CompanyName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CompanyName] ON [dbo].[Company]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CompanyTIN]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CompanyTIN] ON [dbo].[Company]
(
	[TaxIdentificationNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyTypeID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CompanyTypeID] ON [dbo].[Company]
(
	[CompanyTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CompanyTypeName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyTypeName] ON [dbo].[CompanyType]
(
	[CompanyTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Country]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Country] ON [dbo].[Country]
(
	[CountryCode] ASC,
	[CountryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CountryCode]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CountryCode] ON [dbo].[Country]
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CountryName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CountryName] ON [dbo].[Country]
(
	[CountryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ItemGroup]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ItemGroup] ON [dbo].[ItemGroup]
(
	[CompanyID] ASC,
	[ItemGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemGroupCompany]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemGroupCompany] ON [dbo].[ItemGroup]
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemGroupIsActive]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemGroupIsActive] ON [dbo].[ItemGroup]
(
	[IsActive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ItemGroupName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemGroupName] ON [dbo].[ItemGroup]
(
	[ItemGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ItemUnit]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ItemUnit] ON [dbo].[ItemUnit]
(
	[CompanyID] ASC,
	[ItemUnitName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemUnitActive]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemUnitActive] ON [dbo].[ItemUnit]
(
	[IsActive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemUnitCompany]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemUnitCompany] ON [dbo].[ItemUnit]
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ItemUnitName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemUnitName] ON [dbo].[ItemUnit]
(
	[ItemUnitName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_JournalEntry]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_JournalEntry] ON [dbo].[JournalEntry]
(
	[CompanyID] ASC,
	[JournalEntryTypeID] ASC,
	[JournalEntryNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryAccountID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryAccountID] ON [dbo].[JournalEntry]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryCompanyID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryCompanyID] ON [dbo].[JournalEntry]
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryDate]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryDate] ON [dbo].[JournalEntry]
(
	[JournalEntryDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_JournalEntryNumber]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryNumber] ON [dbo].[JournalEntry]
(
	[JournalEntryNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryReferenceID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryReferenceID] ON [dbo].[JournalEntry]
(
	[ReferenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_JournalEntrySourcePath]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntrySourcePath] ON [dbo].[JournalEntry]
(
	[SourcePath] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryTypeID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryTypeID] ON [dbo].[JournalEntry]
(
	[JournalEntryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryDetailAccountID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryDetailAccountID] ON [dbo].[JournalEntryDetail]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryDetailJournalEntryID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryDetailJournalEntryID] ON [dbo].[JournalEntryDetail]
(
	[JournalEntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_JournalEntryType]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_JournalEntryType] ON [dbo].[JournalEntryType]
(
	[CompanyID] ASC,
	[JournalEntryTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_JournalEntryTypeName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryTypeName] ON [dbo].[JournalEntryType]
(
	[JournalEntryTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_NavigationItem]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_NavigationItem] ON [dbo].[NavigationItem]
(
	[CompanyID] ASC,
	[NavigationItemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_NavigationItemName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_NavigationItemName] ON [dbo].[NavigationItem]
(
	[NavigationItemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NavigationItemParentID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_NavigationItemParentID] ON [dbo].[NavigationItem]
(
	[ParentNavigationItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Province]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Province] ON [dbo].[Province]
(
	[CountryID] ASC,
	[ProvinceCode] ASC,
	[ProvinceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProvinceCode]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProvinceCode] ON [dbo].[Province]
(
	[ProvinceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProvinceName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProvinceName] ON [dbo].[Province]
(
	[ProvinceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRole]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserRole] ON [dbo].[UserRole]
(
	[CompanyID] ASC,
	[UserRoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoleName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoleName] ON [dbo].[UserRole]
(
	[UserRoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserCompanyID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserCompanyID] ON [dbo].[Users]
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserEmail]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserEmail] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserFullName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserFullName] ON [dbo].[Users]
(
	[FullName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserMobile]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserMobile] ON [dbo].[Users]
(
	[Mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserName]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserOTP]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserOTP] ON [dbo].[Users]
(
	[OTP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserOTPExpired]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserOTPExpired] ON [dbo].[Users]
(
	[OTPExpired] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserPasswordExpired]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserPasswordExpired] ON [dbo].[Users]
(
	[PasswordExpired] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoleID]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoleID] ON [dbo].[Users]
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users]
(
	[CompanyID] ASC,
	[UserRoleID] ASC,
	[UserName] ASC,
	[Mobile] ASC,
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UsersPassword]    Script Date: 29/12/2024 10:41:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_UsersPassword] ON [dbo].[Users]
(
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ItemGroup] ADD  CONSTRAINT [DF_ItemsGroup_SortOrder]  DEFAULT ((1)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[ItemGroup] ADD  CONSTRAINT [DF_ItemsGroup_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_MarginUnitPrice]  DEFAULT ((0)) FOR [CostUnitPrice]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_ExclusiveTaxUnitPrice]  DEFAULT ((0)) FOR [SellingUnitPrice]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[JournalEntryType] ADD  CONSTRAINT [DF_JournalEntryType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[JournalEntryType] ADD  CONSTRAINT [DF_JournalEntryType_SortOrder]  DEFAULT ((1)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[NavigationItem] ADD  CONSTRAINT [DF_NavigationItem_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_SortOrder]  DEFAULT ((1)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[AccountDetail]  WITH CHECK ADD  CONSTRAINT [FK_AccountDetail_AccountDetail] FOREIGN KEY([AccountParentID])
REFERENCES [dbo].[AccountDetail] ([AccountID])
GO
ALTER TABLE [dbo].[AccountDetail] CHECK CONSTRAINT [FK_AccountDetail_AccountDetail]
GO
ALTER TABLE [dbo].[AccountDetail]  WITH CHECK ADD  CONSTRAINT [FK_AccountDetail_AccountType] FOREIGN KEY([AccountParentID])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[AccountDetail] CHECK CONSTRAINT [FK_AccountDetail_AccountType]
GO
ALTER TABLE [dbo].[AccountDetail]  WITH CHECK ADD  CONSTRAINT [FK_AccountDetail_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[AccountDetail] CHECK CONSTRAINT [FK_AccountDetail_Company]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_CompanyType] FOREIGN KEY([CompanyTypeID])
REFERENCES [dbo].[CompanyType] ([CompanyTypeID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_CompanyType]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Province] FOREIGN KEY([ProvinceID], [CountryID])
REFERENCES [dbo].[Province] ([ProvinceID], [CountryID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Province]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Company]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemGroup] FOREIGN KEY([ItemGroupID])
REFERENCES [dbo].[ItemGroup] ([ItemGroupID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemGroup]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemUnit] FOREIGN KEY([ItemUnitID])
REFERENCES [dbo].[ItemUnit] ([ItemUnitID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemUnit]
GO
ALTER TABLE [dbo].[JournalEntry]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntry_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[JournalEntry] CHECK CONSTRAINT [FK_JournalEntry_Company]
GO
ALTER TABLE [dbo].[JournalEntry]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntry_JournalEntryType] FOREIGN KEY([JournalEntryTypeID])
REFERENCES [dbo].[JournalEntryType] ([JournalEntryTypeID])
GO
ALTER TABLE [dbo].[JournalEntry] CHECK CONSTRAINT [FK_JournalEntry_JournalEntryType]
GO
ALTER TABLE [dbo].[JournalEntryDetail]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntryDetail_JournalEntry] FOREIGN KEY([JournalEntryID])
REFERENCES [dbo].[JournalEntry] ([JournalEntryID])
GO
ALTER TABLE [dbo].[JournalEntryDetail] CHECK CONSTRAINT [FK_JournalEntryDetail_JournalEntry]
GO
ALTER TABLE [dbo].[JournalEntryType]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntryType_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[JournalEntryType] CHECK CONSTRAINT [FK_JournalEntryType_Company]
GO
ALTER TABLE [dbo].[NavigationItem]  WITH CHECK ADD  CONSTRAINT [FK_NavigationItem_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[NavigationItem] CHECK CONSTRAINT [FK_NavigationItem_Company]
GO
ALTER TABLE [dbo].[NavigationItem]  WITH CHECK ADD  CONSTRAINT [FK_NavigationItem_NavigationItem] FOREIGN KEY([ParentNavigationItemID])
REFERENCES [dbo].[NavigationItem] ([NavigationItemID])
GO
ALTER TABLE [dbo].[NavigationItem] CHECK CONSTRAINT [FK_NavigationItem_NavigationItem]
GO
ALTER TABLE [dbo].[Province]  WITH CHECK ADD  CONSTRAINT [FK_Province_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[Province] CHECK CONSTRAINT [FK_Province_Country]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Company]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Company]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRole] FOREIGN KEY([UserRoleID])
REFERENCES [dbo].[UserRole] ([UserRoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRole]
GO
