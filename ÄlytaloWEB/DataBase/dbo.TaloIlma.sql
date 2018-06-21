CREATE TABLE [dbo].[TaloIlma] (
    [Ilma_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Huone]       NVARCHAR (50) NULL,
    [IlmaTilaOff] BIT           NOT NULL,
    [Ilma1]       BIT           NOT NULL,
    [Ilma2]       BIT           NOT NULL,
    [Ilma3]       BIT           NOT NULL,
    [Ilma4]       BIT           NOT NULL,
    [IlmaOn1]     DATETIME      NULL,
    [IlmaOn2]     DATETIME      NULL,
    [IlmaOn3]     DATETIME      NULL,
    [IlmaOn4]     DATETIME      NULL,
    [IlmaOff]     DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Ilma_ID] ASC)
);

