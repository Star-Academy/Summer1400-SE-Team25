import controller.FileHandler;
import controller.QueryHandler;
import util.Config;

public class Main {
    public static void main(String[] args) {
        FileHandler fileHandler = new FileHandler(Config.retrieveProperty("ENGLISH_DATA_PATH"));
        QueryHandler queryHandler = new QueryHandler(fileHandler.getInvertedIndex());
        queryHandler.run();
    }
}