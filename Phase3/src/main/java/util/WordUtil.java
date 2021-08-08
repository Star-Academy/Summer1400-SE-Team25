package util;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import org.tartarus.snowball.ext.PorterStemmer;

public class WordUtil {
    private List<String> stopWords;
    private final String STOP_WORDS_PATH;
    private final PorterStemmer stemmer;

    public WordUtil() {
        stopWords = new ArrayList<>();
        STOP_WORDS_PATH = "src/main/java/StopWords.txt";
        stemmer = new PorterStemmer();
        initStopWords();
    }

    public WordUtil(String STOP_WORDS_PATH) {
        this.STOP_WORDS_PATH = STOP_WORDS_PATH;
        stemmer = new PorterStemmer();
        initStopWords();
    }

    public String extractRootWord(String word){
        word = word.toLowerCase();
        stemmer.setCurrent(word);
        stemmer.stem();
        word = stemmer.getCurrent();
        if (isStopWord(word))
            return null;
        return word;
    }

    private boolean isStopWord(String word) {
        return stopWords.contains(word);
    }

    private void initStopWords() {
        try (var fileScanner = new Scanner(new File(STOP_WORDS_PATH))) {
            while (fileScanner.hasNext())
                stopWords.add(fileScanner.nextLine());
        }
        catch (FileNotFoundException e) {
//            e.printStackTrace();
        }
    }
}
