docker-compose up -d
# cd ../
docker cp Program.cs kyopurocs:/App/Program.cs
docker exec -it kyopurocs bash -c "dotnet run"
