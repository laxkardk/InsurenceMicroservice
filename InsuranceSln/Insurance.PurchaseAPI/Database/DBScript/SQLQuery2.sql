
IF DB_ID('InsurancePurchase') IS NULL
BEGIN

CREATE DATABASE InsurancePurchase

END

Use InsurancePurchase

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = '[dbo].[PurchaseInsurance]'))
BEGIN

CREATE TABLE [dbo].[PurchaseInsurance] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CustomerPolicyID] INT            NOT NULL,
    [CustomerAddress]  NVARCHAR (MAX) NULL,
    [Price]            DECIMAL (18)   NULL,
    [PaymentMethod]    NCHAR (10)     NULL,
    [Quantity]         INT            NULL,
    [IsConfirm]        BIT            NULL,
    [CreatedBy]        NVARCHAR (50)  NULL,
    [CreatedDate]      DATETIME       NULL,
    [ModifiedBy]       NVARCHAR (50)  NULL,
    [ModifiedDate]     DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

END

