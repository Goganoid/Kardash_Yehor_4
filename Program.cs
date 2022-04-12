using Lab4;

Microwave microwave= new(5000,10,10);
Fork fork = new(20, 0, 5);
Plate plate = new(100, 0, 5);

plate.PlaceFood(500);
microwave.Connect();
microwave.Heat(plate);
fork.Prick(plate);
fork.Eat();
plate.Empty();
plate.Wash();
fork.Wash();
// :)
microwave.MoveBy(5,0);
microwave.Wash();
fork.Connect();
fork.Disconnect();

