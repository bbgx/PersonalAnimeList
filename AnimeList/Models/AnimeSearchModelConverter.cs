using AnimeICollection.Models.AnimeModel;
using AnimeList.DTO;
using AutoMapper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimeList.Models
{
    public class AnimeSearchModelConverter : JsonConverter<AnimeSearchModel>
    {
        private readonly IMapper _mapper;

        public AnimeSearchModelConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override AnimeSearchModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var animeSearchModel = new AnimeSearchModel();
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                var root = document.RootElement;

                var paginationElement = root.GetProperty("pagination");
                var items = paginationElement.GetProperty("items");
                var paginationItems = new PaginationItems
                {
                    Count = items.GetProperty("count").GetInt32(),
                    Total = items.GetProperty("total").GetInt32(),
                    PerPage = items.GetProperty("per_page").GetInt32()
                };

                animeSearchModel.Pagination = new Pagination
                {
                    LastVisiblePage = paginationElement.GetProperty("last_visible_page").GetInt32(),
                    HasNextPage = paginationElement.GetProperty("has_next_page").GetBoolean(),
                    CurrentPage = paginationElement.GetProperty("current_page").GetInt32(),
                    Items = paginationItems
                };

                if (root.TryGetProperty("data", out JsonElement dataElement) && dataElement.ValueKind == JsonValueKind.Array)
                {
                    var dataList = new List<BaseAnimeModel>();

                    foreach (var item in dataElement.EnumerateArray())
                    {
                        var animeModel = new BaseAnimeModel();
                        BaseAnimeModelConverter.ReadBaseModelProperties(animeModel, item);
                        dataList.Add(animeModel);

                    }

                    var dtoList = _mapper.Map<List<BaseAnimeModelDTO>>(dataList);
                    animeSearchModel.Data = dtoList;
                }

            }
            return animeSearchModel;
        }

        public override void Write(Utf8JsonWriter writer, AnimeSearchModel value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
