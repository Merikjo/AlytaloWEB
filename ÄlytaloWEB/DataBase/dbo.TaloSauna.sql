CREATE TABLE [dbo].[TaloSauna] (
    [Sauna_ID]              INT           IDENTITY (1, 1) NOT NULL,
    [SaunaNro]              INT           NULL,
    [SaunanNimi]            NVARCHAR (50) NULL,
    [SaunaTavoiteLampotila] NVARCHAR (20) NULL,
    [SaunaNykyLampotila]    NVARCHAR (20) NULL,
    [SaunanTila]            BIT           NOT NULL,
    [SaunaStart]            DATETIME      NULL,
    [SaunaStop]             DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Sauna_ID] ASC)
);

