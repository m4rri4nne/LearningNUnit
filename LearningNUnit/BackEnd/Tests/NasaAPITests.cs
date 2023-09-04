namespace BackEndTests;
public class Tests
{
        
        Requests request = new Requests();

        [Test]
        public void SearchAPODSucess()
        {
            var response = request.NasaAPIRequest();
            response.Should().Be(HttpStatusCode.OK);
        }
}
