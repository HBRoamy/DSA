class Program
{
    static void Main(string[] args)
    {
        var imageResponse = new List<ImageResponse>()
        {
            new ImageResponse()
            {
                ImageId="img1",
                MessageDetails=new List<string>(){"System.ArgumentOutOfRangeException"}
            },
            new ImageResponse()
            {
                ImageId="img2",
                MessageDetails=new List<string>()
            },
            new ImageResponse()
            {
                ImageId="img3",
                MessageDetails=new List<string>()
            },
            new ImageResponse()
            {
                ImageId="img4",
                MessageDetails=new List<string>(){"System.ArgumentOutOfRangeException"}
            },
            new ImageResponse()
            {
                ImageId="img5",
                MessageDetails=new List<string>()
            }
        };

        VehicleImageBatchUpdateRequest request = new VehicleImageBatchUpdateRequest()
        {
            InventoryLotId = "ILID1",
            Vin = "VIN1",
            ImageUpdateRequests = new List<VehicleImageSingleUpdateRequest>()
            {
                //this will be sorted by image id
                new VehicleImageSingleUpdateRequest()
                {
                    ImageFileName="abc1",
                    ImagePosition=1
                },
                new VehicleImageSingleUpdateRequest()
                {
                    ImageFileName="abc2",
                    ImagePosition=2
                },
                new VehicleImageSingleUpdateRequest()
                {
                    ImageFileName="abc3",
                    ImagePosition=3
                },
                new VehicleImageSingleUpdateRequest()
                {
                    ImageFileName="abc4",
                    ImagePosition=4
                },
                new VehicleImageSingleUpdateRequest()
                {
                    ImageFileName="abc5",
                    ImagePosition=5
                }
            }
        };
        List<VehicleImageSingleUpdateRequest> erroneousRequests = new();
        List<ImageResponse> correctResponse = new();
        List<ImageUpdate> newRequest = new();


        int lastCorrectPosition = request.ImageUpdateRequests[0].ImagePosition;
        var updateRequests = request.ImageUpdateRequests;
        //using forloop as we need to different objects in the same loop
        for (int i = 0; i < updateRequests.Count; i++)
        {
            if (imageResponse[i].MessageDetails.Contains("System.ArgumentOutOfRangeException"))
            {
                erroneousRequests.Add(updateRequests[i]);
            }
            else
            {
                //correctResponse.Add(item);
                newRequest.Add(new ImageUpdate()
                {
                    VehicleSetId = request.InventoryLotId,
                    Vin = request.Vin,
                    ImageId = updateRequests[i].ImageFileName,
                    ImagePosition = lastCorrectPosition,
                    PhotoGuideDefinitionCaption = updateRequests[i].PhotoGuideDefinitionCaption

                }); ;
                //currentResponsePosition=lastCorrectPosition
                lastCorrectPosition += 1;
            }
        }

        foreach (var item in erroneousRequests)
        {
            System.Console.WriteLine(item.ImageFileName);
        }

        foreach (var item in newRequest)
        {
            System.Console.WriteLine($"{item.ImageId} now at position {item.ImagePosition}");
        }
    }
}
public class VehicleImageBatchUpdateRequest
{
    public string InventoryLotId { get; set; }
    public string Vin { get; set; }
    public List<VehicleImageSingleUpdateRequest> ImageUpdateRequests { get; set; }
}
public class VehicleImageSingleUpdateRequest
{
    public string ImageFileName { get; set; }

    public int ImagePosition { get; set; }

    public int? PhotoPackageGuideDefinitionXrefID { get; set; }

    public string PhotoGuideDefinitionCaption { get; set; }
}
public class ImageResponse
{
    public string ImageId { get; set; }

    //public List<MessageDetail> MessageDetails { get; set; }
    public List<string> MessageDetails { get; set; }
}
public class ImageUpdate
{
    public string ImageId { get; set; }

    public string VehicleSetId { get; set; }

    public string Vin { get; set; }

    public int ImagePosition { get; set; }

    public string PhotoGuideDefinitionCaption { get; set; }
}