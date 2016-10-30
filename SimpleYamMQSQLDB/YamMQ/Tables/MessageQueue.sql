CREATE TABLE [YamMQ].[MessageQueue] (
    [Id]                UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [SerializedMessage] NVARCHAR (500)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

