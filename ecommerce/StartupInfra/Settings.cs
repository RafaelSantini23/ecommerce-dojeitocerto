namespace ecommerce.StartupInfra
{
    public record Settings
    {
        public required SqlServerSettings sqlServerSettings { get; init; }
    }

    public record SqlServerSettings
    {
        public required string connectionString { get; init; }
    }
}
