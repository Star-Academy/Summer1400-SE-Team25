import controller.FileHandler;
import controller.QueryHandler;

public class Main {
    public static void main(String[] args) {
        FileHandler fileHandler = new FileHandler("EnglishData");
        QueryHandler queryHandler = new QueryHandler(fileHandler.getInvertedIndex());
        queryHandler.run();
    }
}