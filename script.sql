USE [VinoDB]
GO
/****** Object:  Table [dbo].[AirExps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Service] [nvarchar](max) NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[MawbNumber] [nvarchar](max) NULL,
	[TypeOfBillId] [int] NOT NULL,
	[FlightNumber] [nvarchar](max) NULL,
	[FlyDate] [datetimeoffset](7) NOT NULL,
	[OpicId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[OriginPortId] [int] NOT NULL,
	[TransitPortId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[CarrierId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[DestinationId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AirExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AirImps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirImps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[MawbNumber] [nvarchar](max) NOT NULL,
	[FlightNumber] [nvarchar](max) NOT NULL,
	[FLyDate] [datetimeoffset](7) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[TypeOfBillId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[Service] [nvarchar](max) NULL,
	[AolId] [int] NOT NULL,
	[DeliveryId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[AirlineId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[AodId] [int] NOT NULL,
	[Routing] [nvarchar](max) NOT NULL,
	[Scn] [nvarchar](max) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AirImps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FullEnglishName] [nvarchar](max) NOT NULL,
	[Contact] [nvarchar](max) NULL,
	[Cell] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Carriers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CrmContacts]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrmContacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EnglishName] [nvarchar](50) NOT NULL,
	[PositionId] [int] NOT NULL,
	[HomeAddress] [nvarchar](max) NULL,
	[CellPhone] [nvarchar](max) NULL,
	[HomePhone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CompanyExt] [nvarchar](max) NULL,
	[Signature] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[Birthday] [datetimeoffset](7) NOT NULL,
	[MarriageStatus] [bit] NOT NULL,
	[SpouseName] [nvarchar](max) NULL,
	[SpouseBirthday] [datetimeoffset](7) NOT NULL,
	[FieldInterested] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CrmContacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CrmCustomers]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrmCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FullEngishName] [nvarchar](max) NULL,
	[FullVietNamName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ContactId] [int] NOT NULL,
	[WorkPhone] [nvarchar](max) NULL,
	[HomePhone] [nvarchar](max) NULL,
	[FaxNo] [nvarchar](max) NULL,
	[LocationId] [int] NOT NULL,
	[Taxcode] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[Website] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CrmCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Districts]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceId] [int] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Districts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailAccounts]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](512) NOT NULL,
	[DisplayName] [nvarchar](512) NOT NULL,
	[Host] [nvarchar](512) NOT NULL,
	[Port] [int] NOT NULL,
	[Username] [nvarchar](512) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[EnableSsl] [bit] NOT NULL,
	[UseDefaultCredentials] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.EmailAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeDatas]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDatas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LastUpdatedAt] [datetimeoffset](7) NOT NULL,
	[Settings] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.EmployeeDatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ProvinceId] [int] NULL,
	[DistrictId] [int] NULL,
	[Phone] [nvarchar](max) NULL,
	[DayOfBirth] [datetime] NULL,
	[Email] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[ImageRecordId] [int] NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[Apps] [nvarchar](max) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[IsValidated] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FclExps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[BkgNumber] [nvarchar](max) NOT NULL,
	[Mbl] [nvarchar](max) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[PoNumber] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[VesselId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[PolId] [int] NOT NULL,
	[FreightId] [int] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[SlinesId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[PodId] [int] NOT NULL,
	[Service] [nvarchar](max) NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.FclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FclImps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FclImps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[MblNumber] [nvarchar](max) NOT NULL,
	[PolId] [int] NOT NULL,
	[Service] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[OpIcId] [int] NOT NULL,
	[ScName] [nvarchar](max) NOT NULL,
	[PoNumber] [nvarchar](max) NOT NULL,
	[PodId] [int] NOT NULL,
	[Container] [nvarchar](max) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[SlinesId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[VesselId] [int] NOT NULL,
	[VoyageId] [int] NOT NULL,
	[DeliveryId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.FclImps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HblFclExps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HblFclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FclExpId] [int] NOT NULL,
	[BlNumber] [nvarchar](max) NOT NULL,
	[BookingNumber] [nvarchar](max) NOT NULL,
	[HblType] [int] NOT NULL,
	[ShipperId] [int] NOT NULL,
	[ConsigneeId] [int] NOT NULL,
	[NotifyPartyId] [int] NOT NULL,
	[LocalVessel] [int] NOT NULL,
	[PlaceOfReceiptId] [int] NOT NULL,
	[OceanVessel] [int] NULL,
	[PortOfLoaingId] [int] NOT NULL,
	[PortOfDischargeId] [int] NOT NULL,
	[TranshipmentPortId] [int] NOT NULL,
	[Container] [nvarchar](max) NULL,
	[NumberOfPackage] [int] NOT NULL,
	[QtyOfContainer] [nvarchar](max) NULL,
	[PoNumber] [nvarchar](max) NULL,
	[DescriptionOfGoods] [nvarchar](max) NULL,
	[GrossWeight] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Measurement] [float] NOT NULL,
	[OnBoardStatus] [nvarchar](max) NULL,
	[ForwardingAgent] [nvarchar](max) NOT NULL,
	[FreightAmount] [float] NOT NULL,
	[ExRef] [datetimeoffset](7) NULL,
	[ReferenceNumber] [float] NOT NULL,
	[FinalDestinationId] [int] NOT NULL,
	[PlaceOfDeliveryId] [int] NOT NULL,
	[CountryOfOriginId] [int] NOT NULL,
	[TypeOfMoveId] [int] NULL,
	[ClosingDate] [datetimeoffset](7) NOT NULL,
	[FreightPayableId] [int] NULL,
	[NumberOfOriginal] [int] NOT NULL,
	[SailingDate] [datetimeoffset](7) NOT NULL,
	[DeliveryOfGoodsId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[PlaceOfIssueId] [int] NULL,
	[IssueDate] [datetimeoffset](7) NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.HblFclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HblLclExps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HblLclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LclExpId] [int] NOT NULL,
	[BlNumber] [nvarchar](max) NOT NULL,
	[BookingNumber] [nvarchar](max) NOT NULL,
	[HblType] [int] NOT NULL,
	[ShipperId] [int] NOT NULL,
	[ConsigneeId] [int] NOT NULL,
	[NotifyPartyId] [int] NOT NULL,
	[LocalVessel] [int] NOT NULL,
	[PlaceOfReceiptId] [int] NOT NULL,
	[OceanVessel] [int] NULL,
	[PortOfLoaingId] [int] NOT NULL,
	[PortOfDischargeId] [int] NOT NULL,
	[TranshipmentPortId] [int] NOT NULL,
	[Container] [nvarchar](max) NULL,
	[NumberOfPackage] [int] NOT NULL,
	[QtyOfContainer] [nvarchar](max) NULL,
	[PoNumber] [nvarchar](max) NULL,
	[DescriptionOfGoods] [nvarchar](max) NULL,
	[GrossWeight] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Measurement] [float] NOT NULL,
	[OnBoardStatus] [nvarchar](max) NULL,
	[ForwardingAgent] [nvarchar](max) NOT NULL,
	[FreightAmount] [float] NOT NULL,
	[ExRef] [datetimeoffset](7) NULL,
	[ReferenceNumber] [float] NOT NULL,
	[FinalDestinationId] [int] NOT NULL,
	[PlaceOfDeliveryId] [int] NOT NULL,
	[CountryOfOriginId] [int] NOT NULL,
	[TypeOfMoveId] [int] NULL,
	[ClosingDate] [datetimeoffset](7) NOT NULL,
	[FreightPayableId] [int] NULL,
	[NumberOfOriginal] [int] NOT NULL,
	[SailingDate] [datetimeoffset](7) NOT NULL,
	[DeliveryOfGoodsId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[PlaceOfIssueId] [int] NULL,
	[IssueDate] [datetimeoffset](7) NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.HblLclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImageRecords]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[RelativePath] [nvarchar](max) NULL,
	[AbsolutePath] [nvarchar](max) NULL,
	[IsExternal] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ImageRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LclExps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[BkgNumber] [nvarchar](max) NOT NULL,
	[MblNumber] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[VesselId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[PolId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[Packages] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[CoLoaderId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[PodId] [int] NOT NULL,
	[FreightId] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LclImps]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LclImps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[MblNumber] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[PolId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[ScName] [nvarchar](max) NOT NULL,
	[VesselId] [int] NOT NULL,
	[PodId] [int] NOT NULL,
	[Packages] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Service] [nvarchar](max) NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[SlinesId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[VoyageId] [int] NOT NULL,
	[DeliveryId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LclImps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginTokens]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [nvarchar](1024) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LoginTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogLevel] [int] NOT NULL,
	[ShortMessage] [nvarchar](max) NULL,
	[FullMessage] [nvarchar](max) NULL,
	[Context] [nvarchar](max) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookups]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Code] [nvarchar](32) NOT NULL,
	[Order] [int] NOT NULL,
	[Title] [nvarchar](256) NULL,
	[App] [nvarchar](3) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Lookups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageTemplates]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BccEmailAddresses] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[DelayBeforeSend] [int] NULL,
	[AttachedDownloadId] [int] NOT NULL,
	[EmailAccountId] [int] NOT NULL,
	[Delay] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.MessageTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderGenCodes]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderGenCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrefix] [nvarchar](max) NULL,
	[CurrentDate] [datetimeoffset](7) NOT NULL,
	[Begin] [int] NOT NULL,
	[CurrentNumber] [int] NOT NULL,
	[End] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.OrderGenCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ports]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PortCode] [nvarchar](max) NOT NULL,
	[PortName] [nvarchar](max) NOT NULL,
	[NationalityId] [int] NOT NULL,
	[ZoneId] [int] NOT NULL,
	[LocalZone] [nvarchar](max) NOT NULL,
	[ModeId] [int] NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Ports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Provinces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QueuedEmails]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueuedEmails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [int] NOT NULL,
	[From] [nvarchar](max) NULL,
	[FromName] [nvarchar](max) NULL,
	[To] [nvarchar](max) NULL,
	[ToName] [nvarchar](max) NULL,
	[CC] [nvarchar](max) NULL,
	[Bcc] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[AttachmentFilePath] [nvarchar](max) NULL,
	[AttachmentFileName] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[SentTries] [int] NOT NULL,
	[SentOn] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.QueuedEmails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topics]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ImageId] [int] NULL,
	[Type] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_Role]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_Role](
	[SystemName] [nvarchar](128) NOT NULL,
	[Display] [nvarchar](32) NULL,
	[Active] [bit] NOT NULL,
	[Permissons] [nvarchar](1024) NULL,
 CONSTRAINT [PK_dbo.z_Role] PRIMARY KEY CLUSTERED 
(
	[SystemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_Setting]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.z_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_User]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](64) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[AvatarUrl] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
	[Roles] [nvarchar](max) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.z_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_UserClaim]    Script Date: 07/26/2018 9:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimName] [nvarchar](32) NULL,
	[ClaimValue] [nvarchar](1024) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.z_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Carriers] ON 

INSERT [dbo].[Carriers] ([Id], [Code], [Name], [FullEnglishName], [Contact], [Cell], [CountryId], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'CL180726001', N'Sang1', N'Sang1Nguyen', NULL, NULL, 65, NULL, NULL, CAST(N'2018-07-26T08:11:06.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[Carriers] OFF
SET IDENTITY_INSERT [dbo].[CrmContacts] ON 

INSERT [dbo].[CrmContacts] ([Id], [ContactId], [FirstName], [LastName], [EnglishName], [PositionId], [HomeAddress], [CellPhone], [HomePhone], [Email], [CompanyExt], [Signature], [DepartmentId], [Birthday], [MarriageStatus], [SpouseName], [SpouseBirthday], [FieldInterested], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'CT180726001', N'Sang1', N'Nguyen', N'Sang1nguyen', 16, N'2/7 đường 106 phường Tăng Nhơn Phú A', N'1628886014', N'1628886014', N'sang1@example.com', N'it', N'sang1', 26, CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), 0, NULL, CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, NULL, CAST(N'2018-07-26T08:08:30.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[CrmContacts] OFF
SET IDENTITY_INSERT [dbo].[CrmCustomers] ON 

INSERT [dbo].[CrmCustomers] ([Id], [CustomerId], [Name], [FullEngishName], [FullVietNamName], [Address], [ContactId], [WorkPhone], [HomePhone], [FaxNo], [LocationId], [Taxcode], [CategoryId], [Website], [Email], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'CS180726002', N'Sang1', NULL, N'Hoàng Sang1', N'2/7 đường 106 phường Tăng Nhơn Phú A', 1, N'1628886014', NULL, NULL, 84, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-07-26T08:10:44.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[CrmCustomers] OFF
SET IDENTITY_INSERT [dbo].[FclExps] ON 

INSERT [dbo].[FclExps] ([Id], [JobId], [Created], [Etd], [BkgNumber], [Mbl], [Eta], [PoNumber], [MblTypeId], [VesselId], [ShipmentId], [PolId], [FreightId], [OpIcId], [IsFinish], [SlinesId], [AgentId], [CommodityId], [PodId], [Service], [Gw], [Cbm], [Notes], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'FLF1807/0001', CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), N'123', N'abc123', CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), N'1234', 70, 74, 33, 1, 79, 1, 1, 1, 1, 5, 1, N'no service', 0, 4, NULL, NULL, NULL, CAST(N'2018-07-26T08:12:08.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[FclExps] OFF
SET IDENTITY_INSERT [dbo].[HblFclExps] ON 

INSERT [dbo].[HblFclExps] ([Id], [FclExpId], [BlNumber], [BookingNumber], [HblType], [ShipperId], [ConsigneeId], [NotifyPartyId], [LocalVessel], [PlaceOfReceiptId], [OceanVessel], [PortOfLoaingId], [PortOfDischargeId], [TranshipmentPortId], [Container], [NumberOfPackage], [QtyOfContainer], [PoNumber], [DescriptionOfGoods], [GrossWeight], [UnitId], [Measurement], [OnBoardStatus], [ForwardingAgent], [FreightAmount], [ExRef], [ReferenceNumber], [FinalDestinationId], [PlaceOfDeliveryId], [CountryOfOriginId], [TypeOfMoveId], [ClosingDate], [FreightPayableId], [NumberOfOriginal], [SailingDate], [DeliveryOfGoodsId], [CommodityId], [PlaceOfIssueId], [IssueDate], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, 1, N'FLLEVN1807/0002', N'1234567', 37, 1, 1, 1, 74, 1, NULL, 1, 1, 1, NULL, 1, N'CONTAINER', NULL, NULL, 4, 40, 2, NULL, N'FREIGHT LINKS CO., LTD-2/7 đường 106 phường Tăng Nhơn Phú A-1628886014', 0, NULL, 0, 1, 1, 65, NULL, CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), NULL, 0, CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), 1, 7, NULL, CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), N'Admin', CAST(N'2018-07-26T08:20:48.0000000+07:00' AS DateTimeOffset), CAST(N'2018-07-26T08:15:07.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[HblFclExps] OFF
SET IDENTITY_INSERT [dbo].[ImageRecords] ON 

INSERT [dbo].[ImageRecords] ([Id], [FileName], [RelativePath], [AbsolutePath], [IsExternal], [CreatedAt], [IsUsed], [Deleted]) VALUES (1, N'img_636681892656470902lcl.jpg', N'\Upload\Image\img_636681892656470902lcl.jpg', N'http:/localhost:63198/Upload/Image/img_636681892656470902lcl.jpg', 0, CAST(N'2018-07-26T08:07:45.6675522+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[ImageRecords] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (1, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-26T08:03:58.3830683+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (2, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-26T08:06:27.3810318+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (3, 40, N'An error occurred while updating the entries. See the inner exception for details.', N'System.Data.Entity.Infrastructure.DbUpdateException: An error occurred while updating the entries. See the inner exception for details. ---> System.Data.Entity.Core.UpdateException: An error occurred while updating the entries. See the inner exception for details. ---> System.Data.SqlClient.SqlException: Cannot insert the value NULL into column ''CategoryId'', table ''VinoDB.dbo.CrmCustomers''; column does not allow nulls. INSERT fails.
The statement has been terminated.
   at System.Data.SqlClient.SqlCommand.<>c.<ExecuteDbDataReaderAsync>b__180_0(Task`1 result)
   at System.Threading.Tasks.ContinuationResultTaskFromResultTask`2.InnerInvoke()
   at System.Threading.Tasks.Task.Execute()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Utilities.TaskExtensions.CultureAwaiter`1.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
   --- End of inner exception stack trace ---
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
   --- End of inner exception stack trace ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Services.MainServices.BaseService.GenericRepository`3.<CreateAsync>d__5.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\BaseService\GenericRepository.cs:line 59
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.CustomersController.<Create>d__9.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\CustomersController.cs:line 104
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.InvokeEndHandler(IAsyncResult ar)
   at System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)', N'', CAST(N'2018-07-26T08:08:54.2478125+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (4, 40, N'Missing type map configuration or unsupported mapping.

Mapping types:
HblFclExpModel -> HblLclExp
Vino.Server.Services.MainServices.CRM.HblFclExp.Models.HblFclExpModel -> Vino.Server.Data.CRM.HblLclExp', N'AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.

Mapping types:
HblFclExpModel -> HblLclExp
Vino.Server.Services.MainServices.CRM.HblFclExp.Models.HblFclExpModel -> Vino.Server.Data.CRM.HblLclExp
   at lambda_method(Closure , Object , Object , ResolutionContext )
   at AutoMapper.Mapper.AutoMapper.IMapper.Map(Object source, Type sourceType, Type destinationType)
   at Falcon.Web.Core.Helpers.AutoMapperExtension.MapTo[TResult](Object self)
   at Vino.Server.Services.MainServices.BaseService.GenericRepository`3.<CreateAsync>d__5.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\BaseService\GenericRepository.cs:line 56
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.HblFclExpController.<Create>d__16.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\HblFclExpController.cs:line 167
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.InvokeEndHandler(IAsyncResult ar)
   at System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)', N'', CAST(N'2018-07-26T08:13:03.6012923+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (5, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-26T08:14:30.4671305+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (6, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-26T08:18:36.7825718+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (7, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-26T08:20:13.1356984+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (8, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-26T08:33:14.0471082+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (9, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-26T08:36:22.8937661+07:00' AS DateTimeOffset), 0)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Lookups] ON 

INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (1, 20, N'0', 0, N'-', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (2, 20, N'1', 0, N'Nam', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (3, 20, N'2', 0, N'Nữ', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (4, 45, N'1', 0, N'Seafood', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (5, 45, N'2', 0, N'Electtronics & Electrical material', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (6, 45, N'3', 0, N'Coffee', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (7, 45, N'4', 0, N'Paper & Chemical Products', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (8, 45, N'5', 0, N'Marble & Tiles', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (9, 45, N'6', 0, N'Rice', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (10, 45, N'7', 0, N'Funiture, Frames, Wood Articles', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (11, 45, N'8', 0, N'Machinery, Utensils & Metalware', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (12, 45, N'9', 0, N'Glass, Ceramic and Plasticware', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (13, 45, N'10', 0, N'Textiles, Gaments and accessories', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (14, 45, N'11', 0, N'Foods & Beverages', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (15, 45, N'12', 0, N'Others', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (16, 46, N'1', 0, N'Oversea Manager', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (17, 46, N'2', 0, N'Nomination', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (18, 46, N'3', 0, N'Account Manager', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (19, 46, N'4', 0, N'General Director', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (20, 46, N'5', 0, N'Accountant', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (21, 46, N'6', 0, N'Staff', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (22, 46, N'7', 0, N'Operation Executive', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (23, 46, N'8', 0, N'Director', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (24, 46, N'8', 0, N'FLC', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (25, 47, N'DP001', 0, N'BOD', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (26, 47, N'DP002', 0, N'Sales', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (27, 47, N'DP003', 0, N'Accounting', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (28, 47, N'DP004', 0, N'Operation', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (29, 47, N'DP005', 0, N'Oversea', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (30, 47, N'DP006', 0, N'HAN Office', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (31, 47, N'DP007', 0, N'FLC', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (32, 47, N'DP008', 0, N'Nomination', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (33, 48, N'1', 0, N'FREE-HAND', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (34, 48, N'2', 0, N'NOMINATED', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (35, 49, N'1', 0, N'FREIGHT PREPAID', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (36, 49, N'2', 0, N'FREIGHT COLLECT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (37, 50, N'1', 0, N'COPY', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (38, 50, N'2', 0, N'ORIGINAL', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (39, 50, N'3', 0, N'SURRENDERED', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (40, 51, N'1', 0, N'BAG', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (41, 51, N'2', 0, N'CBM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (42, 51, N'3', 0, N'BOXES', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (43, 51, N'4', 0, N'BL', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (44, 52, N'1', 0, N'DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (45, 52, N'2', 0, N'SEA&AIR', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (46, 52, N'3', 0, N'SEA&AIR&INLAND&DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (47, 52, N'4', 0, N'AIR&INLAND', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (48, 52, N'5', 0, N'INLAND&DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (49, 52, N'6', 0, N'SEA&DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (50, 52, N'7', 0, N'SEA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (51, 52, N'8', 0, N'AIR', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (52, 52, N'8', 0, N'SEA&AIR&INLAND', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (53, 52, N'9', 0, N'EXPRESS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (54, 53, N'1', 0, N'AFRICA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (55, 53, N'2', 0, N'Central America', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (56, 53, N'3', 0, N'Oceania', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (57, 53, N'4', 0, N'South Asia', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (58, 53, N'5', 0, N'EUROPE', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (59, 53, N'6', 0, N'MIDDLE EAST', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (60, 53, N'7', 0, N'North Asia', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (61, 53, N'8', 0, N'North America', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (62, 53, N'9', 0, N'South America', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (63, 53, N'10', 0, N'ASIA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (64, 53, N'11', 0, N'OTHERS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (65, 54, N'1', 0, N'ARMENIA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (66, 54, N'2', 0, N'ARUBA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (67, 54, N'3', 0, N'AUSTRIA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (68, 54, N'4', 0, N'AZERBAIJAN', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (69, 54, N'5', 0, N'BAHAMAS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (70, 55, N'1', 0, N'COPY', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (71, 55, N'2', 0, N'ORIGINAL', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (72, 55, N'3', 0, N'SEAWAY B/L', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (73, 55, N'4', 0, N'SURRENDERED', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (74, 56, N'1', 0, N'BANI BHUM V.773S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (75, 56, N'2', 0, N'EVER POWER V.0112-234S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (76, 56, N'3', 0, N'HANSA HOMBURG V.163S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (77, 56, N'4', 0, N'HEUNG-A JANICE V. 0072N', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (78, 56, N'5', 0, N'LEDA TRADER V.0021N', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (79, 57, N'1', 0, N'COLLECT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (80, 57, N'1', 0, N'PREPAID', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (81, 58, N'1', 0, N'0020S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (82, 58, N'2', 0, N'17004S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (83, 58, N'3', 0, N'17006S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (84, 59, N'domestic', 0, N'Domestic', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (85, 59, N'overseas', 0, N'Overseas', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (86, 60, N'agent-domestic', 0, N'AGENT - DOMESTIC', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (87, 60, N'agent-overseas', 0, N'AGENT - OVERSEAS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (88, 60, N'co-loader', 0, N'CO-LOADER', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (89, 60, N'direct-consignee', 0, N'DIRECT CONSIGNEE', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (90, 60, N'direct-customer', 0, N'DIRECT CUSTOMER', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (91, 60, N'direct-shipper', 0, N'DIRECT SHIPPER', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (92, 61, N'FCL/FCL-CY/CY', 0, N'FCL/FCL-CY/CY', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (93, 61, N'LCL/LCL-CFS/CFS', 0, N'LCL/LCL-CFS/CFS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (94, 62, N'cat-lai-kho-1', 0, N'CAT LAI KHO 1', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (95, 62, N'hai-phong-viet-nam', 0, N'HAI PHONG , VIETNAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (96, 62, N'ho-chi-minh-port-viet-nam', 0, N'HO CHI MINH PORT, VIETNAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (97, 62, N'ho-chi-minh-viet-nam', 0, N'HOCHIMINH CITY, VIET NAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (98, 62, N'quy-nhon-viet-nam', 0, N'QUINHON, VIETNAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (99, 63, N'Company', 0, N'Company', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Lookups] OFF
SET IDENTITY_INSERT [dbo].[OrderGenCodes] ON 

INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (1, N'FLF', CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 1, 999, 0)
INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (2, N'CT', CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 1, 999, 0)
INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (3, N'CS', CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 2, 999, 0)
INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (4, N'CL', CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 1, 999, 0)
INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (5, N'FLLEVN', CAST(N'2018-07-26T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 2, 999, 0)
SET IDENTITY_INSERT [dbo].[OrderGenCodes] OFF
SET IDENTITY_INSERT [dbo].[Ports] ON 

INSERT [dbo].[Ports] ([Id], [PortCode], [PortName], [NationalityId], [ZoneId], [LocalZone], [ModeId], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'EVN', N'Quận 9', 65, 55, N'VN', 44, NULL, NULL, CAST(N'2018-07-26T08:11:38.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[Ports] OFF
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([Id], [Name], [Phone], [Address], [ImageId], [Type], [Deleted]) VALUES (1, N'FREIGHT LINKS CO., LTD', N'1628886014', N'2/7 đường 106 phường Tăng Nhơn Phú A', 1, N'Company', 0)
SET IDENTITY_INSERT [dbo].[Topics] OFF
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Admin', N'Quản trị', 1, N'AccessAdminPanel;ManageFalconUsers;ManageExaminationProcedure;ManageMessageTemplates;ManageSettings;ManageActivityLog;ManageSystemLog;ManageMessageQueue;ManageMaintenance;ManageNews;ManageHospital;ManageFeedback;ManageRole;ManageLookup;ManageRoom;ManageShift;ManageProduct;ManageMasterItem;ManageMap;ManageFeedback;ManageUserHospital;ManageReserved;ManageEmployee;ManageCalendarException;ManageCategory;ManageOrder;ManageSensorType;ManageDevice;ManageDeviceSeri;ManageCalendar;ManageFact;ManageAction;ManageActionFact;ManageFactSensor;ManageProvince;ManageGateway;ManageNewsFeed;ManageMessage;ManageQuestion;ManageTopic;ManageContact;ManageWaitingRegister;ManageSubscription;ManageSupplier;ManageWarehouse;ManageGrowingZone;ManageBreed;ManageCustomer')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Employee', N'Nhân viên', 1, N'')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Manager', N'Quản lý Cấp cao', 1, N'AccessAdminPanel;ManageCategory;ManageProduct;ManageOrder;ManageNewsFeed;ManageNews;ManageTopic;ManageContact;ManageEmployee')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Operator', N'Vận hành hệ thống', 1, N'AccessAdminPanel')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'ProducingManager', N'Quản lý Sản xuất', 1, N'')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'ProducingStaff', N'Nhân viên Sản xuất', 1, N'AccessAdminPanel')
SET IDENTITY_INSERT [dbo].[z_Setting] ON 

INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (1, N'securitysettings.encryptionkey', N'1150917619028207')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (2, N'securitysettings.uniquetoken', N'True')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (3, N'securitysettings.tokenlifetime', N'1440')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (4, N'securitysettings.cookielifetime', N'8544')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (5, N'systemsettings.cachelong', N'1440')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (6, N'systemsettings.cachenormal', N'90')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (7, N'systemsettings.cacheshort', N'5')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (8, N'systemsettings.domain', N'http://localhost:63198/')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (9, N'emailsettings.emailwelcometemplate', N'<p><span style="font-size:medium;"data-mce-mark="1"><strong>Ch&agrave;o mừng {@*userName}&nbsp;<span style="color:inherit;font-family:inherit;" data-mce-mark="1">tham gia Vino</span></strong></span></p><p>&nbsp;</p><p>Cảm ơn bạn đ&atilde; đăng k&yacute; t&agrave;i khoản tr&ecirc;n Vino.&nbsp;</p><p>Mật khẩu của bạn l&agrave;{@*password}</p><p>Th&acirc;n mến,</p><p><strong style="font-size:medium;"> BQT & nbsp; Vino</strong></p>')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (10, N'emailsettings.emailwelcometitle', N'Chào mừng thành viên của Vino')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (11, N'emailsettings.emailresetpasswordtemplate', N'<p>Dear <strong>{@*userName}</strong> !</p>
<p><br />Theo y&ecirc;u cầu của bạn, mật khẩu đăng nhập tr&ecirc;n <span style="color: #0000ff;">Vino</span> đ&atilde; được cấp mới. Chi tiết t&agrave;i khoản của bạn hiện tại như sau:</p>
<p>T&agrave;i khoản đăng nhập: {@*userName}</p>
<p>T&ecirc;n hiển thị: {@*displayName}</p><p>&nbsp;</p>
<p>Th&acirc;n mến,</p>
<p><span style="font-size: medium;"><strong>BQT Vino</strong></span></p>')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (12, N'emailsettings.emailresetpasswordtitle', N'Thông báo v/v đặt lại mật khẩu trên Vino')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (13, N'mediasettings.targetresize', N'100')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (14, N'metadatasettings.lastupdatedlookup', N'')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (15, N'metadatasettings.uploadingfolder', N'Uploads')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (16, N'metadatasettings.photosizepercent', N'5')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (17, N'metadatasettings.photomaxwidth', N'1024')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (18, N'metadatasettings.resizemode', N'ByMaxWidth')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (19, N'metadatasettings.numberofdaygetnewslatest', N'7')
SET IDENTITY_INSERT [dbo].[z_Setting] OFF
SET IDENTITY_INSERT [dbo].[z_User] ON 

INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (1, N'Admin', N'', NULL, N'53D36461B6EE8E383538260BCD4A83AB0A68FB51', N'S5pCLBoq', 1, N'Admin', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (2, N'manager', N'', NULL, N'01E5440A4C1107395273CFCC5A2B1E9ABB1FC61B', N'II78GNNt', 1, N'Manager', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (3, N'operator', N'', NULL, N'69E4047B5F5A723899B0A7CDECA0F70D0492E68A', N'OMsEJNI5', 1, N'Operator', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (4, N'employee', N'', NULL, N'D0351FE9BC3AC78319F66A9865F3E2F5CDE4EF58', N'WHelyTFB', 1, N'Employee', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (5, N'user1', N'', NULL, N'E3BBA100581E4052F4D344346F6F1C262BB8F0E1', N'gnac/X9E', 1, N'ProducingStaff', 0)
SET IDENTITY_INSERT [dbo].[z_User] OFF
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_CarrierId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.CrmContacts_OpicId] FOREIGN KEY([OpicId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.CrmContacts_OpicId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Ports_DestinationId] FOREIGN KEY([DestinationId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Ports_DestinationId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Ports_OriginPortId] FOREIGN KEY([OriginPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Ports_OriginPortId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Ports_TransitPortId] FOREIGN KEY([TransitPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Ports_TransitPortId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AirlineId] FOREIGN KEY([AirlineId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AirlineId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AodId] FOREIGN KEY([AodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AodId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AolId] FOREIGN KEY([AolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AolId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Ports_DeliveryId] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Ports_DeliveryId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Carriers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Carriers_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carriers] CHECK CONSTRAINT [FK_dbo.Carriers_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[CrmContacts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmContacts_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CrmContacts] CHECK CONSTRAINT [FK_dbo.CrmContacts_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.CrmContacts_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.CrmContacts_ContactId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Lookups] ([Id])
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_CategoryId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Lookups] ([Id])
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_LocationId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Districts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Districts_dbo.Provinces_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Districts] CHECK CONSTRAINT [FK_dbo.Districts_dbo.Provinces_ProvinceId]
GO
ALTER TABLE [dbo].[EmployeeDatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmployeeDatas_dbo.Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeDatas] CHECK CONSTRAINT [FK_dbo.EmployeeDatas_dbo.Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Districts_DistrictId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.ImageRecords_ImageRecordId] FOREIGN KEY([ImageRecordId])
REFERENCES [dbo].[ImageRecords] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.ImageRecords_ImageRecordId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Provinces_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Provinces_ProvinceId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.z_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.z_User_UserId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_SlinesId] FOREIGN KEY([SlinesId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_SlinesId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_SlinesId] FOREIGN KEY([SlinesId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_SlinesId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Ports_DeliveryId] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Ports_DeliveryId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ConsigneeId] FOREIGN KEY([ConsigneeId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ConsigneeId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_DeliveryOfGoodsId] FOREIGN KEY([DeliveryOfGoodsId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_DeliveryOfGoodsId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_NotifyPartyId] FOREIGN KEY([NotifyPartyId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_NotifyPartyId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ShipperId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.FclExps_FclExpId] FOREIGN KEY([FclExpId])
REFERENCES [dbo].[FclExps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.FclExps_FclExpId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_FinalDestinationId] FOREIGN KEY([FinalDestinationId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_FinalDestinationId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfDeliveryId] FOREIGN KEY([PlaceOfDeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfDeliveryId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfReceiptId] FOREIGN KEY([PlaceOfReceiptId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfReceiptId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfDischargeId] FOREIGN KEY([PortOfDischargeId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfDischargeId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfLoaingId] FOREIGN KEY([PortOfLoaingId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfLoaingId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_TranshipmentPortId] FOREIGN KEY([TranshipmentPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_TranshipmentPortId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ConsigneeId] FOREIGN KEY([ConsigneeId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ConsigneeId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_DeliveryOfGoodsId] FOREIGN KEY([DeliveryOfGoodsId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_DeliveryOfGoodsId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_NotifyPartyId] FOREIGN KEY([NotifyPartyId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_NotifyPartyId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ShipperId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.LclExps_LclExpId] FOREIGN KEY([LclExpId])
REFERENCES [dbo].[LclExps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.LclExps_LclExpId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_FinalDestinationId] FOREIGN KEY([FinalDestinationId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_FinalDestinationId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfDeliveryId] FOREIGN KEY([PlaceOfDeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfDeliveryId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfReceiptId] FOREIGN KEY([PlaceOfReceiptId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfReceiptId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfDischargeId] FOREIGN KEY([PortOfDischargeId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfDischargeId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfLoaingId] FOREIGN KEY([PortOfLoaingId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfLoaingId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_TranshipmentPortId] FOREIGN KEY([TranshipmentPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_TranshipmentPortId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_CoLoaderId] FOREIGN KEY([CoLoaderId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_CoLoaderId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_SlinesId] FOREIGN KEY([SlinesId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_SlinesId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Ports_DeliveryId] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Ports_DeliveryId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Ports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Ports_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ports] CHECK CONSTRAINT [FK_dbo.Ports_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Topics_dbo.ImageRecords_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[ImageRecords] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_dbo.Topics_dbo.ImageRecords_ImageId]
GO
ALTER TABLE [dbo].[z_UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.z_UserClaim_dbo.z_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[z_UserClaim] CHECK CONSTRAINT [FK_dbo.z_UserClaim_dbo.z_User_UserId]
GO
