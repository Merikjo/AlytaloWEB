CREATE TABLE [dbo].[TaloValo] (
    [Valo_ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Huone]        NVARCHAR (50) NULL,
    [ValaisinType] NVARCHAR (50) NULL,
    [Lamppu_ID]    VARCHAR (5)   NULL,
    [ValoTilaOff]  BIT           NOT NULL,
    [Valo33]       BIT           NOT NULL,
    [Valo66]       BIT           NOT NULL,
    [Valo100]      BIT           NOT NULL,
    [ValoOn33]     DATETIME      NULL,
    [ValoOn66]     DATETIME      NULL,
    [ValoOn100]    DATETIME      NULL,
    [ValoOff]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Valo_ID] ASC)
);

