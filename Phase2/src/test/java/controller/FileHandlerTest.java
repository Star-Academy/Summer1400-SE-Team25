package controller;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import model.FileMapper;

@RunWith(MockitoJUnitRunner.class)
public class FileHandlerTest {
    private FileHandler fileHandler;

    @Mock
    private FileMapper fileMapper;

    @Before
    public void setUp() {
        this.fileHandler = new FileHandler(fileMapper);
    }

    @Test(expected = NullPointerException.class)
    public void initializeTest() {
        fileHandler.initialize("A dir name that doesn't exist");
    }
}
