using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public class InsertSqlComandProvider : IInsertSqlComandProvider 
    {
        public string Command => @"insert into
                                    Products(Cost,
                                    Name,
                                    Description,
                                    UserId,
                                    PowerInWatt,
                                    Brand,
                                    ProductivityKgPerMin,
                                    Country,
                                    WeightInGrams,
                                    Color,
                                    LengthMm,
                                    WidthMm,
                                    HeightMm,
                                    VolumeLiters,
                                    Category,
                                    ScreenSize,
                                    Cores,
                                    Resolution,
                                    VideoCard,
                                    BatteryVolume,
                                    CorpuseType,
                                    Image)
                                    values(@Cost,
                                    @Name,
                                    @Description,
                                    @SalerId,
                                    @PowerInWatt,
                                    @Brand,
                                    @ProductivityKgPerMin,
                                    @Country,
                                    @WeightInGrams,
                                    @Color,
                                    @LengthMm,
                                    @WidthMm,
                                    @HeightMm,
                                    @VolumeLiters,
                                    @Category,
                                    @ScreenSize,
                                    @Cores,
                                    @Resolution,
                                    @VideoCard,
                                    @BatteryVolume,
                                    @CorpuseType,
                                    @Image);";
    }
}
