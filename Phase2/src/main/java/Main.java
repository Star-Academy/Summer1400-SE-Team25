import controller.FileHandler;
import controller.QueryHandler;
import controller.SearchEngine;
import model.InvertedIndex;
import view.UserView;

public class Main {
    final static String DEFAULT_PATH = "src/main/java/EnglishData";
    public static void main(String[] args) {
        var invertedIndex = new InvertedIndex();
        var fileHandler = new FileHandler(invertedIndex);
        fileHandler.initialize(DEFAULT_PATH);
        var queryHandler = new QueryHandler(invertedIndex);
        var searchEngine = new SearchEngine(queryHandler);
        var userView = new UserView(searchEngine);
        userView.run();
    }
}