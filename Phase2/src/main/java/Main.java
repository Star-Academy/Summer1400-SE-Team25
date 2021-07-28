import controller.FileHandler;
import controller.QueryHandler;
import controller.SearchEngine;
import model.FileMapper;
import model.InvertedIndex;
import view.UserView;

public class Main {
    public static void main(String[] args) {
        InvertedIndex invertedIndex = new InvertedIndex();
        FileMapper fileMapper = new FileMapper(invertedIndex);
        FileHandler fileHandler = new FileHandler(fileMapper);
        fileHandler.initialize();
        QueryHandler queryHandler = new QueryHandler(invertedIndex);
        SearchEngine searchEngine = new SearchEngine(queryHandler);
        UserView userView = new UserView(searchEngine);
        userView.run();
    }
}