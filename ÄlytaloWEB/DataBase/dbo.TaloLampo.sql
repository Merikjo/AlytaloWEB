CREATE TABLE [dbo].[TaloLampo] (
    [Huone_ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Huone]             NVARCHAR (50) NULL,
    [HuoneTavoiteLampo] NVARCHAR (50) NULL,
    [HuoneNykyLampo]    NVARCHAR (50) NULL,
    [LampoKirjattu]     DATETIME      NULL,
    [LampoOn]           BIT           NOT NULL,
    [LampoOff]          BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Huone_ID] ASC)
);

