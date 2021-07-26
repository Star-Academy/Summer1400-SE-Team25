package view;

import controller.FileHandler;
import controller.QueryHandler;
import util.Config;

public class SearchEngine {
    private FileHandler fileHandler;
    private QueryHandler queryHandler;

    public SearchEngine() {
        fileHandler = new FileHandler(Config.retrieveProperty("ENGLISH_DATA_PATH"));
        queryHandler = new QueryHandler(fileHandler.getInvertedIndex());
        queryHandler.run();
    }
}
