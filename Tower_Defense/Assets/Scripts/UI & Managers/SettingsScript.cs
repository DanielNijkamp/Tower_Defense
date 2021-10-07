using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsScript : MonoBehaviour
{
    public float SFXSliderVolume;
    public float BGMSliderVolume;

    public Slider BGMSlider;
    public Slider SFXSlider;

    public TextMeshProUGUI BGMText;
    public TextMeshProUGUI SFXText;

    public Button backButton;
    public Button trollbutton;

    public GameObject MainMenuCanvas;

    public GameObject settingsCanvas;

    private static SettingsScript setscript;

    [HideInInspector] public bool SettingIsOpen = false;


    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;

    public Volume m_Volume;

    public GameObject volumeobject;

    public Bloom m_Bloom = null;
    public Tonemapping m_Tonemapping = null;
    public ChromaticAberration m_CA = null;

    public TMPro.TMP_Dropdown QualityDropdown;



    public Toggle pp_toggle;
    public Toggle bloom_toggle;
    public Toggle TM_toggle;
    public Toggle CA_toggle;



    public bool PP_bool;
    public bool Bloom_bool;
    public bool TM_bool;
    public bool CA_bool;

    public void ShowSettings()
    {
        SettingIsOpen = true;
        settingsCanvas.SetActive(true);
    }
    void Start()
    {

        float BGMSliderPerfs = PlayerPrefs.GetFloat("BGMSlider", 50);
        float SFXSliderPerfs = PlayerPrefs.GetFloat("BGMSlider", 50);
        BGMSlider.value = BGMSliderPerfs;
        SFXSlider.value = SFXSliderPerfs;
        SFXChanged(SFXSliderPerfs);
        BGMChanged(BGMSliderPerfs);

        VolumeProfile proflile = m_Volume.sharedProfile;

        volumeobject.SetActive(true);


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void BGMChanged(float value)
    {
        BGMSliderVolume = value;
        FindObjectOfType<SoundManagerScript>().ChangeBGMVolume(BGMSliderVolume);
        BGMText.text = value + "%";
        PlayerPrefs.SetFloat("BGMSlider", value);
        PlayerPrefs.Save();
    }
    public void SFXChanged(float value)
    {
        SFXSliderVolume = value;
        FindObjectOfType<SoundManagerScript>().ChangeSFXVolume(SFXSliderVolume);
        SFXText.text = value + "%";
        PlayerPrefs.SetFloat("SFXSlider", value);
        PlayerPrefs.Save();
    }

    public void OnBGMSliderChanged()
    {
        BGMChanged(BGMSlider.value);
    }

    public void OnSFXSliderChanged()
    {
        SFXChanged(SFXSlider.value);
    }
    private void OnEnable()
    {
        BGMSlider.onValueChanged.AddListener(delegate { OnBGMSliderChanged(); });
        SFXSlider.onValueChanged.AddListener(delegate { OnSFXSliderChanged(); });

    }
    void OnDisable()
    {
        BGMSlider.onValueChanged.RemoveAllListeners();
        SFXSlider.onValueChanged.RemoveAllListeners();
    }
    


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    

    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void TogglePostProcessing()
    {
        if (pp_toggle.isOn == true)
        {
            m_Volume.enabled = true;
            PP_bool = true;
        }
        else
        {
            m_Volume.enabled = false;
            PP_bool = false;
        }
    }
    public void ToggleBloom()
    {
        if (bloom_toggle.isOn == true)
        {
            m_Bloom.active = true;
            Bloom_bool = true;
        }
        else
        {
            m_Bloom.active = false;
            Bloom_bool = false;

        }
    }
    public void ToggleToneMapping()
    {
        if (TM_toggle.isOn == true)
        {
            m_Tonemapping.active = true;
            TM_bool = true;
        }
        else
        {
            m_Tonemapping.active = false;
            TM_bool = false;

        }
    }
    public void ToggleChromaticAbberation()
    {
        if (CA_toggle.isOn == true)
        {
            m_CA.active = true;
            CA_bool = true;
        }
        else
        {
            m_CA.active = false;
            CA_bool = false;

        }
    }



    private void Awake()
    {
        GetInfo();
        Initiallize();

    }
    void GetInfo()
    {
        m_Volume.profile.TryGet(out m_Bloom);
        m_Volume.profile.TryGet(out m_Tonemapping);
        m_Volume.profile.TryGet(out m_CA);

    }
    void Initiallize()
    {
        pp_toggle.isOn = true;
        bloom_toggle.isOn = true;
        TM_toggle.isOn = true;
        CA_toggle.isOn = false;
        

        m_Volume.enabled = true;
        m_Bloom.active = true;
        m_Tonemapping.active = true;
        m_CA.active = false;

    }




}