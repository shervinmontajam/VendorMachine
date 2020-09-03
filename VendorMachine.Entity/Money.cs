namespace VendorMachine.Entity
{
    public sealed class Money
    {

        public static readonly Money Zero = new Money(0, 0, 0, 0);
        public static readonly Money TenCent = new Money(1, 0, 0, 0);
        public static readonly Money TwentyCent = new Money(0, 1, 0, 0);
        public static readonly Money FiftyCent = new Money(0, 0, 1, 0);
        public static readonly Money OneEuro = new Money(0, 0, 0, 1);


        public int TenCentCount { get; }
        public int TwentyCentCount { get; }
        public int FiftyCentCount { get; }
        public int OneEuroCount { get; }

        public Money(int tenCent, int twentyCent, int fiftyCent, int oneEuro)
        {
            TenCentCount = tenCent;
            TwentyCentCount = twentyCent;
            FiftyCentCount = fiftyCent;
            OneEuroCount = oneEuro;
        }

        public decimal Total => TenCentCount * 0.10m + TwentyCentCount * 0.20m + FiftyCentCount * 0.50m + OneEuroCount;

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(
                money1.TenCentCount + money2.TenCentCount,
                money1.TwentyCentCount + money2.TwentyCentCount,
                money1.FiftyCentCount + money2.FiftyCentCount,
                money1.OneEuroCount + money2.OneEuroCount);
        }


        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.TenCentCount - money2.TenCentCount,
                money1.TwentyCentCount - money2.TwentyCentCount,
                money1.FiftyCentCount - money2.FiftyCentCount,
                money1.OneEuroCount - money2.OneEuroCount);
        }

    }
}
