USE [Logistics]
GO
/****** Object:  Table [dbo].[LclExpSis]    Script Date: 08/07/2018 3:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LclExpSis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LclExpId] [int] NOT NULL,
	[ReferenceNo] [nvarchar](max) NOT NULL,
	[BookingNumber] [nvarchar](max) NOT NULL,
	[Attn] [nvarchar](max) NOT NULL,
	[ShippingLines] [nvarchar](max) NULL,
	[ShipperInfo] [nvarchar](max) NOT NULL,
	[RealShipperInfo] [nvarchar](max) NULL,
	[ConsigneeInfo] [nvarchar](max) NOT NULL,
	[RealConsigneeInfo] [nvarchar](max) NULL,
	[NotifyPartyInfo] [nvarchar](max) NOT NULL,
	[PortofLoadingId] [int] NOT NULL,
	[PortofDischargeId] [int] NOT NULL,
	[PlaceOfDeliveryId] [int] NOT NULL,
	[VesselId] [int] NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[Container] [nvarchar](max) NULL,
	[DescriptionOfGoods] [nvarchar](max) NULL,
	[QtyOfContainer] [nvarchar](max) NULL,
	[Packages] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[Remark] [int] NULL,
	[PaymentId] [int] NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[CrmCustomer_Id] [int] NULL,
	[CrmCustomer_Id1] [int] NULL,
	[CrmCustomer_Id2] [int] NULL,
	[CrmCustomer_Id3] [int] NULL,
	[CrmCustomer_Id4] [int] NULL,
 CONSTRAINT [PK_dbo.LclExpSis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id] FOREIGN KEY([CrmCustomer_Id])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id1] FOREIGN KEY([CrmCustomer_Id1])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id1]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id2] FOREIGN KEY([CrmCustomer_Id2])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id2]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id3] FOREIGN KEY([CrmCustomer_Id3])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id3]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id4] FOREIGN KEY([CrmCustomer_Id4])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.CrmCustomers_CrmCustomer_Id4]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.LclExps_LclExpId] FOREIGN KEY([LclExpId])
REFERENCES [dbo].[LclExps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.LclExps_LclExpId]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.Ports_PlaceOfDeliveryId] FOREIGN KEY([PlaceOfDeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.Ports_PlaceOfDeliveryId]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.Ports_PortofLoadingId] FOREIGN KEY([PortofLoadingId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.Ports_PortofLoadingId]
GO
ALTER TABLE [dbo].[LclExpSis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExpSis_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[LclExpSis] CHECK CONSTRAINT [FK_dbo.LclExpSis_dbo.z_User_CreatorId]
GO
