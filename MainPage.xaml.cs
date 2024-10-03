namespace MancillaHexColor
{
    public partial class MainPage : ContentPage
    {
        private bool isRandom = false;

        public MainPage()
        {
            InitializeComponent();
        
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                // Get slider values
                var red = slRed.Value;
                var green = slGreen.Value;
                var blue = slBlue.Value;

                // Create the color and update the background
                Color color = Color.FromRgb(red, green, blue);
                SetColor(color);

                // Determine if the image should be visible based on slider values
                UpdateGifVisibility(red, green, blue);
            }
        }

        private void UpdateGifVisibility(double red, double green, double blue)
        {
            if (red == 255 && green == 0 && blue == 0)
            {
                gif.Source = new HtmlWebViewSource
                {
                    Html = @"
                            <html>
                                <body>
                                    <img src='file:///android_asset/Resources/Images/fighterjet.gif' style='width:100%; height:100%;'/>
                                </body>
                            </html>"
                };
                gif.IsVisible = true;
                gif1.IsVisible = false;
                gif2.IsVisible = false;
                gif3.IsVisible = false;
            }
            else if (red == 0 && green == 255 && blue == 0)
            {
                gif1.Source = new HtmlWebViewSource
                {
                    Html = @"
                            <html>
                                <body>
                                    <img src='file:///android_asset/Resources/Images/skeletontree.gif' style='width:100%; height:100%;'/>
                                </body>
                            </html>"
                };
                gif.IsVisible = false;
                gif1.IsVisible = true;
                gif2.IsVisible = false;
                gif3.IsVisible = false;
            }
            else if (red == 0 && green == 0 && blue == 255)
            {
                gif2.Source = new HtmlWebViewSource
                {
                    Html = @"
                            <html>
                                <body>
                                    <img src='file:///android_asset/Resources/Images/runningguko.gif' style='width:100%; height:100%;'/>
                                </body>
                            </html>"
                };
                gif.IsVisible = false;
                gif1.IsVisible = false;
                gif2.IsVisible = true;
                gif3.IsVisible = false;
            }
            else
            {
                // Hide all GIFs if no primary color is selected
                gif.IsVisible = false;
                gif1.IsVisible = false;
                gif2.IsVisible = false;
                gif3.IsVisible = false;
            }
        }

        void OnRedButtonClicked(object sender, EventArgs e)
        {
            // Set sliders to the red value
            slRed.Value = 255;
            slGreen.Value = 0;
            slBlue.Value = 0;

            // Update the background color and image
            SetColor(Color.FromRgb(255, 0, 0));
            gif.Source = new HtmlWebViewSource
            {
                        Html = @"
                                <html>
                                    <body>
                                        <img src='file:///android_asset/Resources/Images/fighterjet.gif' style='width:100%; height:100%;'/>
                                    </body>
                                </html>"
            };
            gif.IsVisible = true;
            gif1.IsVisible = false;
            gif2.IsVisible = false;
            gif3.IsVisible = false;
        }

        void OnGreenButtonClicked(object sender, EventArgs e)
        {
            // Set sliders to the green value
            slRed.Value = 0;
            slGreen.Value = 255;
            slBlue.Value = 0;

            // Update the background color and image
            SetColor(Color.FromRgb(0, 255, 0));
            gif1.Source = new HtmlWebViewSource
            {
                Html = @"
                                <html>
                                    <body>
                                        <img src='file:///android_asset/Resources/Images/skeletontree.gif' style='width:100%; height:100%;'/>
                                    </body>
                                </html>"
            };
            gif.IsVisible = false;
            gif1.IsVisible = true;
            gif2.IsVisible = false;
            gif3.IsVisible = false;

        }
        private void OnRandomColorButtonClicked(object sender, EventArgs e)
        {
            isRandom = true;

            // Generate random RGB values
            Random random = new Random();
            int red = random.Next(256);   // Generates a value between 0 and 255
            int green = random.Next(256);
            int blue = random.Next(256);

            // Create the color and update the background
            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);

            // Update sliders with random values
            slRed.Value = red;
            slGreen.Value = green;
            slBlue.Value = blue;

            // Call OnSliderValueChanged to apply the generated color
            OnSliderValueChanged(null, null);

            // Select a random GIF from the array
            int gifIndex = random.Next(gifUrls.Length); // Get a random index
            string selectedGifUrl = gifUrls[gifIndex]; // Get the corresponding GIF URL

            // Update WebView source with the selected GIF
            gif3.Source = new HtmlWebViewSource
            {
                Html = $@"
            <html>
                <body>
                    <img src='{selectedGifUrl}' style='width:100%; height:100%;'/>
                </body>
            </html>"
            };

            gif3.IsVisible = true; 
            gif.IsVisible = false;
            gif1.IsVisible = false;
            gif2.IsVisible = false;
            isRandom = false;
        }

        private readonly string[] gifUrls = new string[]
            {
                "file:///android_asset/Resources/Images/soldierOne.gif",
                "file:///android_asset/Resources/Images/soldierTwo.gif",
                "file:///android_asset/Resources/Images/soldierThree.gif",
                "file:///android_asset/Resources/Images/soldierFour.gif",
                "file:///android_asset/Resources/Images/soldierFive.gif",
                "file:///android_asset/Resources/Images/soldierSix.gif",
                "file:///android_asset/Resources/Images/soldierSeven.gif"
            };

        private async void OnCopyButtonClipboard(object sender, EventArgs e)
        {
            string hexColor = lblHex.Text;

            // Check if the text is not null or empty
            if (!string.IsNullOrEmpty(hexColor))
            {
                // Copy to clipboard
                await Clipboard.SetTextAsync(hexColor);

              // Show a message or toast to indicate that the text has been copied
                await DisplayAlert("Copied", "Hex color copied to clipboard!", "OK");
            }
        }


        void OnBlueButtonClicked(object sender, EventArgs e)
        {
            // Set sliders to the blue value
            slRed.Value = 0;
            slGreen.Value = 0;
            slBlue.Value = 255;

            // Update the background color and image
            SetColor(Color.FromRgb(0, 0, 255));
            gif2.Source = new HtmlWebViewSource
            {
                Html = @"
                                <html>
                                    <body>
                                        <img src='file:///android_asset/Resources/Images/runningguko.gif' style='width:100%; height:100%;'/>
                                    </body>
                                </html>"
            };
            gif.IsVisible = false;
            gif1.IsVisible = false;
            gif2.IsVisible = true;
            gif3.IsVisible = false;
        }

        private void SetColor(Color color)
        {
            // Update the background color of the container
            backgroundBox.Color = color;

            // Update the hex value label
            string hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }
    }

}
