CREATE TABLE [dbo].[PolicyMaster] (
    [PolicyId]          NUMERIC (18)    IDENTITY (1, 1) NOT NULL,
    [PolicyName]        NVARCHAR (50)   NOT NULL,
    [PolicyDescription] NVARCHAR (MAX)  NULL,
    [PolicyLaunchDate]             DATETIME NULL,
    [PolicyCategory]    NVARCHAR (50)   NULL,
    [isActive]          BIT             DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([PolicyId] ASC)
);

