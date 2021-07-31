package view;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.when;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.PrintStream;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import controller.SearchEngine;

@RunWith(MockitoJUnitRunner.class)
public class UserViewTest {
    private final ByteArrayInputStream inContent = new ByteArrayInputStream("Test".getBytes());
    private final ByteArrayOutputStream outContent = new ByteArrayOutputStream();

    private final InputStream originalIn = System.in;
    private final PrintStream originalOut = System.out;

    UserView view;

    @Mock
    SearchEngine engine;


    @Before
    public void setUp() {
        System.setIn(inContent);
        System.setOut(new PrintStream(outContent));

        view = new UserView(engine);

        when(engine.search("Test")).thenReturn("Doc1");
    }

    @Test
    public void TestRun() {
        view.run();
        String result = outContent.toString();
        assertEquals("Enter search query:\r\nDoc1", result);
    }

    @After
    public void cleanUp() {
        System.setIn(originalIn);
        System.setOut(originalOut);
    }
}
