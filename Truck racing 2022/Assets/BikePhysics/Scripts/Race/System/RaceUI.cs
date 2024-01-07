//Race_UI.cs handles displaying all UI in the race.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RGSK;
using UnityEngine.Advertisements;
//using Prime31;

namespace RGSK
{
    public class RaceUI : MonoBehaviour
    {

        #region Grouped UI Classes
        [System.Serializable]
        public class RacerInfoUI
        {
            public Text position;
            public Text name;
            public Image countryImg;//uday
            public Text vehicleName;
            public Text bestLapTime;
            public Text totalTime;
        }

        [System.Serializable]
        public class RacingUI
        {
            public Text rank, rankPos;

            public Text lap;
            public Text currentLapTime;
            public Text previousLapTime;
            public Text bestLapTime;
            public Text totalTime;
            public Text countdown;
            public Text raceInfo;
            public Text finishedText;


            public Sprite[] aiFlags;

            [Header("In Race Standings")]
            public List<RacerInfoUI> inRaceStandings = new List<RacerInfoUI>();
            public Color[] RefColor;

            public Color playerColor = Color.green;
            public Color normalColor = Color.white;

            [Header("Wrongway Indication")]
            public Text wrongwayText;
            public Image wrongwayImage;
        }

        [System.Serializable]
        public class DriftingUI
        {
            public GameObject driftPanel;
            public Text totalDriftPoints;
            public Text currentDriftPoints;
            public Text driftMultiplier;
            public Text driftStatus;
            public Text goldPoints, silverPoints, bronzePoints;
        }

        [System.Serializable]
        public class DriftResults
        {
            public Text totalPoints;
            public Text driftRaceTime;
            public Text bestDrift;
            public Text longestDrift;
            public Image gold, silver, bronze;
        }
        public void Share()
        {
            //			FBMainMenu.Instance.ShareLevelCompleteNormal ();
        }
        public void UnlockCars()
        {
            //			GoogleIAB.purchaseProduct (InAppPurchaseManager.allSkus [6]);
        }
        public void UnlockLevels()
        {
            //			GoogleIAB.purchaseProduct (InAppPurchaseManager.allSkus [7]);
        }
        [System.Serializable]
        public class VehicleUI
        {
            public Text currentSpeed;
            public Text currentGear;
            public Image nitroBar;
            public Image SpeedoBar;//uday
            public TextMesh speedText3D, gearText3D;
            private string speedUnit;

            [Header("Speedometer")]
            public RectTransform needle;
            public float minNeedleAngle = -20.0f;
            public float maxNeedleAngle = 220.0f;
            public float rotationMultiplier = 0.85f;
            [HideInInspector]
            public float needleRotation;
        }

        [System.Serializable]
        public class Rewards
        {
            public Text rewardCurrency;
            public Text RacePosTxt;
            public Text racePosTag;
        }
        #endregion

        public static RaceUI instance;
        public Statistics player;
        private DriftPointController driftpointcontroller;
        public Image HintFailImage;

        [Header("Starting Grid UI")]
        public GameObject startingGridPanel;
        public List<RacerInfoUI> startingGrid = new List<RacerInfoUI>();

        [Header("Racing UI")]
        public GameObject racePanel;
        public GameObject pausePanel;
        public RacingUI racingUI;
        public DriftingUI driftUI;
        public VehicleUI vehicleUI;

        [Header("Fail Race UI")]
        public GameObject failRacePanel;
        public Text failTitle;
        public Text failReason;

        [Header("Race Finished UI")]
        public GameObject raceCompletePanel;
        public GameObject raceResultsPanel, driftResultsPanel;
        public List<RacerInfoUI> raceResults = new List<RacerInfoUI>();
        public DriftResults driftResults;
        public Rewards rewardTexts;
        public Text TotalCurrencytxt;
        public Text Currentlvltxt;
        public MotionBlur MotionObject;

        [Header("Replay UI")]
        public GameObject replayPanel;
        public Image progressBar;

        [Header("ScreenFade")]
        public Image screenFade;
        public float fadeSpeed = 0.5f;
        public bool fadeOnStart = true;
        public bool fadeOnExit = true;

        [Header("Scene Ref")]
        public string menuScene = "Menu";

        [HideInInspector]
        public List<string> raceInfos = new List<string>();

        public GameObject NitroEffectImg;
        public Image CamerascreenFade;
        public GameObject AirEffect;

        void Awake()
        {
            instance = this;
        }
        public static bool AdType;

        public Text PlayerTotalTime;

        public int randomAiFlags;


        void Start()
        {
          
            randomAiFlags = 0;

            //startingGridPanel.SetActive (true);

            if (fadeOnStart && screenFade) StartCoroutine(ScreenFadeOut(fadeSpeed));

            ClearUI();

            ConfigureUiBasedOnRaceType();

            UpdateUIPanels();
            //			if (gameConfigs.mee) 
            //			{
            //				if (!AdType) 
            //				{
            //					gameConfigs.mee.runActions (gameConfigs.INGAME_page, 0);
            //				}
            //
            //			}
            //			GameConfigs2018.mee.showRotationAds (MenuManager.CurrentLevel,AdsPageType.ingame);

            //	Player_biker = player.GetComponent<Car_Controller> ();
            //			vehicleUI.nitroBar.fillAmount = 0;
            //ingame
           // AdManager.instance.RequestInterstitial();
          //  Advertisement.Initialize("4269105");

            lightcolor[0].SetActive(true);
            lightcolor[1].SetActive(true);
            lightcolor[2].SetActive(true);
            lightcolor[3].SetActive(false);

            lightcolor[4].SetActive(false);

            lightcolor[5].SetActive(false);

            print("current level++=================" + MenuManager.CurrentLevel);
            //			HelpPopups.SetActive (true);//uday

            //			AudioListener.volume = 0;

            //			Car_Controller.mee.engineAudioSource.Stop ();

            //if (AdManager.instance) {
            //    AdManager.instance.RunActions(AdManager.PageType.InGame, CurrentTrackDetails.instance.currentLevel);
            //}

           // FirebaseManager.instance.Levelstart(CurrentTrackDetails.instance.currentLevel);
        }



        public void ShowAd()
        {
            //			if (gameConfigs.mee) {
            //
            //				if (!AdType) 
            //				{
            //					gameConfigs.mee.runActions (gameConfigs.LEVELCOMPLETE_page, 0);
            //				} else {
            //					Advertisement.Show ("video");
            //				}
            //			}
            //			AdType = !AdType;
        }
        //public Motorbike_Controller Player_biker;
        //	public Car_Controller Player_biker;
        void ClearUI()
        {
            //Clear Starting Grid
            //			if (startingGrid.Count == 0) 
            //			{
            //				OpponentControl.mee.IsNavigateAIStart = true;
            //			
            //			}
            if (startingGrid.Count > 0)
            {
                for (int i = 0; i < startingGrid.Count; i++)
                {
                    startingGrid[i].position.text = string.Empty;
                    startingGrid[i].name.text = string.Empty;
                    startingGrid[i].vehicleName.text = string.Empty;

                }
            }

            //Clear In Race Standings
            if (racingUI.inRaceStandings.Count > 0)
            {
                for (int i = 0; i < racingUI.inRaceStandings.Count; i++)
                {
                    racingUI.inRaceStandings[i].position.text = (i + 1).ToString();

                    //					racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite= ProfilePics [2];

                    //Disable the parent if one exists so we can activate it later based on how many racers there are

                    //  if (racingUI.inRaceStandings[i].position.transform.parent)
                    // racingUI.inRaceStandings[i].position.transform.parent.gameObject.SetActive(false);
                }
            }

            //Clear Race Reults
            if (raceResults.Count > 0)
            {
                for (int i = 0; i < raceResults.Count; i++)
                {
                    if (raceResults[i].position) raceResults[i].position.text = string.Empty;
                    if (raceResults[i].name) raceResults[i].name.text = string.Empty;

                    //					if (raceResults[i].country) raceResults[i].country. = string.Empty;


                    if (raceResults[i].totalTime) raceResults[i].totalTime.text = string.Empty;
                    if (raceResults[i].vehicleName) raceResults[i].vehicleName.text = string.Empty;
                    if (raceResults[i].bestLapTime) raceResults[i].bestLapTime.text = string.Empty;
                }
            }

            //Clear other texts
            if (racingUI.raceInfo) racingUI.raceInfo.text = string.Empty;
            if (racingUI.countdown) racingUI.countdown.text = string.Empty;
            if (racingUI.finishedText) racingUI.finishedText.text = string.Empty;
            if (rewardTexts.rewardCurrency) rewardTexts.rewardCurrency.text = string.Empty;
            if (rewardTexts.RacePosTxt) rewardTexts.RacePosTxt.text = string.Empty;

        }


        void ConfigureUiBasedOnRaceType()
        {
            if (!RaceManager.instance) return;

            if (driftUI.driftPanel) driftUI.driftPanel.SetActive(RaceManager.instance._raceType == RaceManager.RaceType.Drift);
            if (raceResultsPanel) raceResultsPanel.SetActive(RaceManager.instance._raceType != RaceManager.RaceType.Drift);
            if (driftResultsPanel) driftResultsPanel.SetActive(RaceManager.instance._raceType == RaceManager.RaceType.Drift);

            if (RaceManager.instance._raceType == RaceManager.RaceType.Drift)
            {
                if (driftUI.goldPoints) driftUI.goldPoints.text = RaceManager.instance.goldDriftPoints.ToString("N0");
                if (driftUI.silverPoints) driftUI.silverPoints.text = RaceManager.instance.silverDriftPoints.ToString("N0");
                if (driftUI.bronzePoints) driftUI.bronzePoints.text = RaceManager.instance.bronzeDriftPoints.ToString("N0");
            }
        }

        void Update()
        {

            //			vehicleUI.SpeedoBar.fillAmount = Mathf.MoveTowards (Car_Controller.mee.currentSpeed, 1,1);


            if (!player)
            {

                if (GameObject.FindGameObjectWithTag("Player"))
                {
                    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Statistics>();
                    //	Player_biker = player.GetComponent<Car_Controller> ();

                    if (player && player.GetComponent<DriftPointController>())
                        driftpointcontroller = player.GetComponent<DriftPointController>();
                }
            }
            else
            {
                UpdateUI();
                VehicleGUI();
            }
        }

        void UpdateUI()
        {
            if (!RaceManager.instance) return;

            switch (RaceManager.instance._raceType)
            {

                case RaceManager.RaceType.Circuit:
                    DefaultUI();
                    break;

                /*case RaceManager.RaceType.Sprint:
                    DefaultUI();
                    break;
                */

                case RaceManager.RaceType.LapKnockout:
                    DefaultUI();
                    break;

                case RaceManager.RaceType.TimeTrial:
                    TimeTrialUI();
                    break;

                case RaceManager.RaceType.SpeedTrap:
                    DefaultUI();
                    break;

                case RaceManager.RaceType.Checkpoints:
                    CheckpointRaceUI();
                    break;

                case RaceManager.RaceType.Elimination:
                    EliminationRaceUI();
                    break;

                case RaceManager.RaceType.Drift:
                    DriftRaceUI();
                    break;
            }

            switch (RaceManager.instance._raceState)
            {
                case RaceManager.RaceState.StartingGrid:
                    //  ShowStartingGrid();
                    break;

                case RaceManager.RaceState.Racing:
                    ShowInRaceStandings();
                    WrongwayUI();
                    break;

                case RaceManager.RaceState.Complete:
                    if (RaceManager.instance._raceType != RaceManager.RaceType.Drift)
                    {
                        ShowRaceResults();
                    }
                    else
                    {
                        ShowDriftResults();
                    }
                    break;

                case RaceManager.RaceState.Replay:
                    ShowReplayUI();
                    break;
            }
        }


        #region RaceTypes UI

        void DefaultUI()
        {
            //POS
            if (racingUI.rank)
                //				racingUI.rank.text = " Position \n" + player.rank + "/"   + RankManager.instance.currentRacers;

                racingUI.rank.text = "Position\n" + "/" + RankManager.instance.currentRacers;

            if (racingUI.rankPos)
                racingUI.rankPos.text = player.rank.ToString();
            //LAP
            if (racingUI.lap)
                racingUI.lap.text = "Lap \n" + player.lap + "/" + RaceManager.instance.totalLaps;

            //LAP TIME
            if (racingUI.currentLapTime)
                racingUI.currentLapTime.text = "Current " + player.currentLapTime;

            //TOTAL TIME
            if (racingUI.totalTime)
                racingUI.totalTime.text = "Total " + player.totalRaceTime;

            //LAST LAP TIME
            if (racingUI.previousLapTime)
                racingUI.previousLapTime.text = GetPrevLapTime();

            //BEST LAP TIME
            if (racingUI.bestLapTime)
                racingUI.bestLapTime.text = GetBestLapTime();
        }


        void TimeTrialUI()
        {
            //POS
            if (racingUI.rank)
                racingUI.rank.text = "Pos " + player.GetComponent<Statistics>().rank + "/" + RankManager.instance.currentRacers;

            //LAP
            if (racingUI.lap)
                racingUI.lap.text = "Lap " + player.lap;

            //LAP TIME
            if (racingUI.currentLapTime)
                racingUI.currentLapTime.text = "Current " + player.currentLapTime;

            //TOTAL TIME
            if (racingUI.totalTime)
                racingUI.totalTime.text = "Total " + player.totalRaceTime;

            //LAST LAP TIME
            if (racingUI.previousLapTime)
                racingUI.previousLapTime.text = GetPrevLapTime();

            //BEST LAP TIME
            if (racingUI.bestLapTime)
                racingUI.bestLapTime.text = GetBestLapTime();

        }


        void CheckpointRaceUI()
        {
            //POS
            if (racingUI.rank)
                racingUI.rank.text = "Pos " + player.GetComponent<Statistics>().rank + "/" + RankManager.instance.currentRacers;

            //CHECKPOINTS
            if (racingUI.lap)
                racingUI.lap.text = "CP " + player.checkpoint + "/" + player.checkpoints.Count * RaceManager.instance.totalLaps;

            //TIMER
            if (racingUI.currentLapTime)
                racingUI.currentLapTime.text = "Time : " + player.currentLapTime;

            //BEST LAP TIME
            if (racingUI.bestLapTime)
                racingUI.bestLapTime.text = GetBestLapTime();

            //EMPTY strings
            if (racingUI.previousLapTime)
                racingUI.previousLapTime.text = "";

            if (racingUI.totalTime)
                racingUI.totalTime.text = "";
        }

        void EliminationRaceUI()
        {
            //POS
            if (racingUI.rank)
                racingUI.rank.text = "Pos " + player.GetComponent<Statistics>().rank + "/" + RankManager.instance.currentRacers;

            //LAP
            if (racingUI.lap)
                racingUI.lap.text = "Lap " + player.lap + "/" + RaceManager.instance.totalLaps;

            //TIMER
            if (racingUI.currentLapTime)
                racingUI.currentLapTime.text = "Time : " + RaceManager.instance.FormatTime(RaceManager.instance.eliminationCounter);

            //TOTAL TIME
            if (racingUI.totalTime)
                racingUI.totalTime.text = "Total " + player.totalRaceTime;

            //LAST LAP
            if (racingUI.previousLapTime)
                racingUI.previousLapTime.text = GetPrevLapTime();

            //BEST LAP
            if (racingUI.bestLapTime)
                racingUI.bestLapTime.text = GetBestLapTime();
        }

        void DriftRaceUI()
        {
            //DRIFT UI
            if (driftUI.totalDriftPoints)
                driftUI.totalDriftPoints.text = player.GetComponent<DriftPointController>().totalDriftPoints.ToString("N0") + " Pts";

            if (driftUI.currentDriftPoints)
                driftUI.currentDriftPoints.text = driftpointcontroller.currentDriftPoints > 0 ? "+ " + player.GetComponent<DriftPointController>().currentDriftPoints.ToString("N0") + " Pts" : string.Empty;

            if (driftUI.driftMultiplier)
                driftUI.driftMultiplier.text = driftpointcontroller.driftMultiplier > 1 ? "x " + driftpointcontroller.driftMultiplier : string.Empty;

            //POS
            if (racingUI.rank)
                racingUI.rank.text = string.Empty;

            //LAP
            if (racingUI.lap)
                racingUI.lap.text = "Lap " + player.lap + "/" + RaceManager.instance.totalLaps;

            //LAP TIME
            if (racingUI.currentLapTime)
                racingUI.currentLapTime.text = "Time " + player.currentLapTime;

            //TOTAL TIME
            if (racingUI.totalTime)
                racingUI.totalTime.text = "Total " + player.totalRaceTime;

            //LAST LAP TIME
            if (racingUI.previousLapTime)
                racingUI.previousLapTime.text = GetPrevLapTime();

            //BEST LAP TIME
            if (racingUI.bestLapTime)
                racingUI.bestLapTime.text = GetBestLapTime();
        }

        #endregion
        //		private string PlayingAnim;
        //		public void ChangeAnim(string AnimToPlay,float SpeedAnim){
        //if (!RaceManager.StopAnims) {


        //				if (AnimToPlay != PlayingAnim) {
        //					PlayingAnim = AnimToPlay;
        //					Player_biker.MyANim.SetTrigger (PlayingAnim);
        //				}
        //				Player_biker.MyANim.speed = SpeedAnim;

        //}
        //		}

        public bool ZeroNitro = true;

        public bool SpeedFiller = true;

        void VehicleGUI()
        {

            //Speed
            if (vehicleUI.currentSpeed) {

                //if (Player_biker == null) {
                //	Player_biker = player.GetComponent<Car_Controller> ();
                //}
                if (player.GetComponent<Car_Controller>())
                    vehicleUI.currentSpeed.text = player.GetComponent<Car_Controller>().currentSpeed.ToString();//+"  "+ player.GetComponent<Car_Controller> ()._speedUnit.ToString ();

                //if (Player_biker)
                //	vehicleUI.currentSpeed.text = Player_biker.currentSpeed + Player_biker._speedUnit.ToString ();





            }

            //Gear
            if (vehicleUI.currentGear)
            {
                if (player.GetComponent<Car_Controller>())
                    vehicleUI.currentGear.text = player.GetComponent<Car_Controller>().currentGear.ToString();

                if (player.GetComponent<Motorbike_Controller>())
                    vehicleUI.currentGear.text = player.GetComponent<Motorbike_Controller>().currentGear.ToString();
            }

            //Speedometer
            if (vehicleUI.needle)
            {
                float fraction = 0;

                if (player.GetComponent<Car_Controller>())
                {
                    fraction = player.GetComponent<Car_Controller>().currentSpeed / vehicleUI.maxNeedleAngle;
                }

                if (player.GetComponent<Motorbike_Controller>())
                {
                    fraction = player.GetComponent<Motorbike_Controller>().currentSpeed / vehicleUI.maxNeedleAngle;
                }

                vehicleUI.needleRotation = Mathf.Lerp(vehicleUI.minNeedleAngle, vehicleUI.maxNeedleAngle, (fraction * vehicleUI.rotationMultiplier));
                vehicleUI.needle.transform.eulerAngles = new Vector3(vehicleUI.needle.transform.eulerAngles.x, vehicleUI.needle.transform.eulerAngles.y, -vehicleUI.needleRotation);
            }

            //Nitro Bar
            if (vehicleUI.nitroBar)
            {
                if (player.GetComponent<Car_Controller>())
                {
                    if (ZeroNitro) {
                        vehicleUI.nitroBar.fillAmount = player.GetComponent<Car_Controller>().nitroCapacity;

                    } else {
                        player.GetComponent<Car_Controller>().nitroCapacity = 1;
                        vehicleUI.nitroBar.fillAmount = player.GetComponent<Car_Controller>().nitroCapacity;

                    }
                    //					Debug.LogError ("Nitro bar fill amount is::"+player.GetComponent<Car_Controller>().nitroCapacity);
                    //					Invoke ("IncreaseNitroSlowly",5.0f);
                    //					vehicleUI.nitroBar.fillAmount = Mathf.MoveTowards (Car_Controller.mee.nitroCapacity, 1,Car_Controller.mee.nitroRegenerationRate * Time.deltaTime);


                }

                //                if (player.GetComponent<Motorbike_Controller>())
                //                    vehicleUI.nitroBar.fillAmount = player.GetComponent<Motorbike_Controller>().nitroCapacity;

            }
            //...............................................................//uday
            if (vehicleUI.SpeedoBar)
            {
                if (player.GetComponent<Car_Controller>())
                {
                    if (SpeedFiller) {
                        vehicleUI.SpeedoBar.fillAmount = player.GetComponent<Car_Controller>().currentSpeed / vehicleUI.maxNeedleAngle;

                    } else {
                        player.GetComponent<Car_Controller>().currentSpeed = 1;
                        vehicleUI.SpeedoBar.fillAmount = player.GetComponent<Car_Controller>().currentSpeed / vehicleUI.maxNeedleAngle;
                    }
                    //					Debug.LogError ("Nitro bar fill amount is::"+player.GetComponent<Car_Controller>().nitroCapacity);
                    //					Invoke ("IncreaseNitroSlowly",5.0f);
                    //					vehicleUI.nitroBar.fillAmount = Mathf.MoveTowards (Car_Controller.mee.nitroCapacity, 1,Car_Controller.mee.nitroRegenerationRate * Time.deltaTime);


                }

                //                if (player.GetComponent<Motorbike_Controller>())
                //                    vehicleUI.nitroBar.fillAmount = player.GetComponent<Motorbike_Controller>().nitroCapacity;

            }
            //...............................................................//uday
            //3D text mesh
            if (!vehicleUI.speedText3D && GameObject.Find("3DSpeedText"))
                vehicleUI.speedText3D = GameObject.Find("3DSpeedText").GetComponent<TextMesh>();

            if (!vehicleUI.gearText3D && GameObject.Find("3DGearText"))
                vehicleUI.gearText3D = GameObject.Find("3DGearText").GetComponent<TextMesh>();

            if (vehicleUI.speedText3D)
            {
                if (player.GetComponent<Car_Controller>())
                    vehicleUI.speedText3D.text = player.GetComponent<Car_Controller>().currentSpeed + player.GetComponent<Car_Controller>()._speedUnit.ToString();

                if (player.GetComponent<Motorbike_Controller>())
                    vehicleUI.speedText3D.text = player.GetComponent<Motorbike_Controller>().currentSpeed + player.GetComponent<Motorbike_Controller>()._speedUnit.ToString();
            }

            if (vehicleUI.gearText3D)
            {
                if (player.GetComponent<Car_Controller>())
                    vehicleUI.gearText3D.text = player.GetComponent<Car_Controller>().currentGear.ToString();

                if (player.GetComponent<Motorbike_Controller>())
                    vehicleUI.gearText3D.text = player.GetComponent<Motorbike_Controller>().currentGear.ToString();
            }
        }


        public void IncreaseNitroSlowly()
        {
            //			if (!Car_Controller.mee.usingNitro && Car_Controller.mee.nitroRegenerationRate > 0) 
            //			{
            //			vehicleUI.nitroBar.fillAmount=Mathf.mo
            vehicleUI.nitroBar.fillAmount = Mathf.MoveTowards(Car_Controller.mee.nitroCapacity, 1, Car_Controller.mee.nitroRegenerationRate * Time.deltaTime);
            ////			vehicleUI.nitroBar.fillAmount =Car_Controller.mee.nitroCapacity;
            //			}
        }

        public void UpdateUIPanels()
        {
            if (!RaceManager.instance) return;

            switch (RaceManager.instance._raceState)
            {
                //if starting grid, set all other panels active to false except from the starting panel
                case RaceManager.RaceState.StartingGrid:
                    if (startingGridPanel) startingGridPanel.SetActive(true);
                    Debug.Log("Starting Grid Help++++++++++++++++++++");
                    Time.timeScale = 0;


                    if (racePanel) racePanel.SetActive(false);

                    if (pausePanel) pausePanel.SetActive(false);

                    if (failRacePanel) failRacePanel.SetActive(false);

                    if (raceCompletePanel) raceCompletePanel.SetActive(false);

                    if (replayPanel) replayPanel.SetActive(false);

                    break;

                //if racing, set all other panels active to false except from the racing panel
                case RaceManager.RaceState.Racing:
                    //  if (startingGridPanel) startingGridPanel.SetActive(false);

                    if (racePanel) racePanel.SetActive(true);

                    if (pausePanel) pausePanel.SetActive(false);

                    if (failRacePanel) failRacePanel.SetActive(false);

                    if (raceCompletePanel) raceCompletePanel.SetActive(false);

                    if (replayPanel) replayPanel.SetActive(false);

                    break;

                //if paused, set all other panels active to false except from the pause panel
                case RaceManager.RaceState.Paused:
                    // if (startingGridPanel) startingGridPanel.SetActive(false);

                    if (racePanel) racePanel.SetActive(false);

                    if (pausePanel) pausePanel.SetActive(true);

                    if (failRacePanel) failRacePanel.SetActive(false);

                    if (raceCompletePanel) raceCompletePanel.SetActive(false);

                    if (replayPanel) replayPanel.SetActive(false);
                    break;

                //if the race is complete, set all other panels active to false except from the completion panel
                case RaceManager.RaceState.Complete:
                    //				if (startingGridPanel)
                    //					startingGridPanel.SetActive (false);

                    if (racePanel)
                        racePanel.SetActive(false);

                    if (pausePanel)
                        pausePanel.SetActive(false);

                    //				if (failRacePanel)
                    //					failRacePanel.SetActive (false);
                    //				
                    if (raceCompletePanel) {
                        raceCompletePanel.SetActive(true);
                        SoundManager.instance.lcs.Play();

                        //					Car_Controller.mee.engineAudioSource.enabled = false;








                        //					Car_Controller.mee.engineAudioSource.GetComponent<AudioListener>().enabled=false;

                        MenuManager.UpdateCoins(CurrentLevelScore);

                        //					if (RankManager.instance.racerRanks == 3) {
                        //					}
                        //					GameConfigs2018.mee.showRotationAds (MenuManager.CurrentLevel,AdsPageType.lc);
                        //					GameConfigs2018.rewardForThisLevel=1000;
                        //					Btm_GPGManager.submitScoreToLeaderBoard (PlayerData.currency);
                        //					Invoke("ShowAd",1);
                        //					GSConfig.CheckAchievments();
                        //					PlayGameServices.submitScore(GSConfig.LeaderBoardID,CurrentLevelScore,"HighScore");//complete add uday
                        if (CurrentLevelScore != 0)
                        {
                            //						GameConfigs2018.rewardForThisLevel = CurrentLevelScore;
                            //						GameConfigs2018.mee.showPreLCScoreDouble ();
                        } else {
                            //						GameConfigs2018.mee.showRotationAds (MenuManager.CurrentLevel,AdsPageType.lc);
                        }

                        //Invoke ("ShowAdLc", 2.5f);

                        //FirebaseManager.instance.Levelcomplete(CurrentTrackDetails.instance.currentLevel);
                        //if (bannerAd.instance)
                        //{
                        //    bannerAd.instance.showMediumBanner();
                        //}
                    }

                    if (replayPanel) replayPanel.SetActive(false);
                    break;

                //if the player is knocked out, set all other panels active to false except from the ko panel
                case RaceManager.RaceState.KnockedOut:
                    if (startingGridPanel)
                        startingGridPanel.SetActive(false);

                    if (racePanel)
                        racePanel.SetActive(false);

                    if (pausePanel)
                        pausePanel.SetActive(false);

                    if (failRacePanel) {
                        //					GameConfigs2018.mee.showRotationAds (MenuManager.CurrentLevel,AdsPageType.lf);



                        failRacePanel.SetActive(true);
                        //Invoke ("ShowAdLf", 2f);

                        Invoke("ShowAd", 1);
                        //FirebaseManager.instance.Levelfail(CurrentTrackDetails.instance.currentLevel);
                        //if (bannerAd.instance)
                        //{
                        //    bannerAd.instance.showMediumBanner();
                        //}

                    }

                    if (raceCompletePanel) raceCompletePanel.SetActive(false);

                    if (replayPanel) replayPanel.SetActive(false);

                    break;

                case RaceManager.RaceState.Replay:
                    if (startingGridPanel) startingGridPanel.SetActive(false);

                    if (racePanel) racePanel.SetActive(false);

                    if (pausePanel) pausePanel.SetActive(false);

                    if (failRacePanel) failRacePanel.SetActive(false);

                    if (raceCompletePanel) raceCompletePanel.SetActive(false);

                    if (replayPanel) replayPanel.SetActive(true);
                    break;

            }
        }

        void ShowAdLc()
        {
            //if (AdManager.instance) {
            //    AdManager.instance.RunActions(AdManager.PageType.LC, CurrentTrackDetails.instance.currentLevel, PlayerPrefs.GetInt("Currency"));
            //}
            AdsManager.Instance.ShowAd();
        }

        void ShowAdLf()
        {
            //if (AdManager.instance) {
            //    AdManager.instance.RunActions(AdManager.PageType.LF, CurrentTrackDetails.instance.currentLevel);
            //}
            AdsManager.Instance.ShowAd();
        }
        private int StoredPos = 100;

        public Sprite[] ProfilePics;//uday

        void ShowStartingGrid()
        {
            //loop through the total number of cars & show their race standings
            if (startingGrid.Count > 0)
            {
                for (int i = 0; i < RankManager.instance.totalRacers; i++)
                {
                    Statistics _statistics = RankManager.instance.racerRanks[i].racer.GetComponent<Statistics>();

                    if (_statistics == null) return;


                    //Position
                    if (startingGrid[i].position) startingGrid[i].position.text = _statistics.rank.ToString();

                    //Name
                    if (startingGrid[i].name) startingGrid[i].name.text = _statistics.racerDetails.racerName;

                    //Vehicle name
                    if (startingGrid[i].vehicleName) startingGrid[i].vehicleName.text = _statistics.racerDetails.vehicleName;

                    print("#### name" + _statistics.racerDetails.racerName);

                    //Debug.Log (_statistics.racerDetails.racerName +" :   "+i+" :: "+_statistics.rank);
                    if (_statistics.racerDetails.racerName == "You" && _statistics.rank >= 6) {

                        StoredPos = _statistics.rank;
                        startingGrid[5].name.text = _statistics.racerDetails.racerName;
                    }


                    if (startingGrid[i].name.text == "You") {
                        startingGrid[i].name.transform.parent.GetComponent<Image>().color = racingUI.RefColor[0];

                    } else {
                        startingGrid[i].name.transform.parent.GetComponent<Image>().color = racingUI.RefColor[1];

                    }
                }

                //				if(StoredPos<100){
                //
                //					startingGrid [5].name.transform.parent.GetComponent<Image> ().color =racingUI.RefColor [0];
                //
                //					startingGrid[5].name.text = "You";
                //					startingGrid[5].position.text = StoredPos.ToString();
                //				}

            }
        }
        void ShowInRaceStandings()
        {
            if (racingUI.inRaceStandings.Count <= 0 || RankManager.instance.totalRacers <= 1)
                return;

            //in race standings
            for (int i = 0; i < RankManager.instance.totalRacers; i++)
            {
                if (i < racingUI.inRaceStandings.Count)
                {
                    Statistics _statistics = RankManager.instance.racerRanks[i].racer.GetComponent<Statistics>();

                    if (_statistics == null) return;


                    //Name
                    if (racingUI.inRaceStandings[i].name) racingUI.inRaceStandings[i].name.text = (RaceManager.instance._raceType != RaceManager.RaceType.SpeedTrap) ? _statistics.racerDetails.racerName
                     : _statistics.racerDetails.racerName + " [" + RankManager.instance.racerRanks[i].speedRecord + " mph]";

                    //					racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite= ProfilePics [MenuManager.ProfilePicNo-1];



                    //Colors
                    if (player == _statistics)
                    {
                        racingUI.inRaceStandings[i].position.color = racingUI.playerColor;
                        racingUI.inRaceStandings[i].name.color = racingUI.playerColor;
                        //						if (PlayerPrefs.GetInt ("Flag") == 0) {
                        racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite = ProfilePics[MenuManager.ProfilePicNo - 1];
                        //						}

                    }
                    else
                    {
                        //						print ("%%%%%%% name " + _statistics.racerDetails.racerName);
                        //						print ("%%%%%%% position " + _statistics.rank);
                        //						if (_statistics.racerDetails.myFlag != null) {
                        //							print ("myflag name " + _statistics.racerDetails.myFlag.name);
                        //						}
                        racingUI.inRaceStandings[i].position.color = racingUI.normalColor;
                        racingUI.inRaceStandings[i].name.color = racingUI.normalColor;

                        if (_statistics.racerDetails.myFlag != null) {
                            //							racingUI.inRaceStandings [i].countryImg.GetComponent<Image> ().sprite = _statistics.racerDetails.myFlag[Statistics.aiFlag];

                            //							racingUI.inRaceStandings [i].countryImg.GetComponent<Image> ().sprite = _statistics.racerDetails.myFlag;

                            //							racingUI.inRaceStandings [i].countryImg.GetComponent<Image> ().sprite = racingUI.aiFlags[randomAiFlags++];
                            //							raceResults[i].countryImg.GetComponent<Image>().sprite = _statistics.racerDetails.myFlag[_statistics.racerDetails.aiFlag]; //nawaz ingame
                            //							print ("random flag "+_statistics.racerDetails.aiFlag);


                            if (_statistics.racerDetails.myFlag != null) {
                                if (_statistics.racerDetails.myFlag == ProfilePics[MenuManager.ProfilePicNo - 1]) {

                                    racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite = ProfilePics[15];
                                }
                                else
                                    racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite = _statistics.racerDetails.myFlag;


                            }

                        }
                        //						print ("random flag "+randomAiFlags);
                        //						int temp;
                        //						temp = Random.Range (MenuManager.ProfilePicNo, MenuManager.ProfilePicNo + 3);
                        //racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite= ProfilePics [i];

                    }
                }
            }
        }

        public void RefreshInRaceStandings()
        {
            if (RankManager.instance.totalRacers <= 1) return;


            Debug.Log("refresh racers");
            for (int i = 0; i < racingUI.inRaceStandings.Count; i++)
            {
                if (i < RankManager.instance.totalRacers)
                {
                    if (racingUI.inRaceStandings[i].position.transform.parent)
                        racingUI.inRaceStandings[i].position.transform.parent.gameObject.SetActive(true);
                }
            }
        }

        /// <summary>
        /// Loops through the total number of racers and shows their standings
        /// This function is called for non drift races because of different UI setup
        /// </summary>
		public void MoreGames()
        {
            Debug.Log("mGames");
            		Application.OpenURL ("https://play.google.com/store/apps/dev?id=7546881258152024025&hl=en");
            //			AdManager.instance.ShowMoreGames();
          //  Application.OpenURL("market://search?q=pub:GT Action Games");

        }
        private Statistics _statistics;
        void ShowRaceResults()
        {
            if (raceResults.Count > 0)
            {


                //				int OurPosition = 0;
                //				for (int i = 0; i < RankManager.instance.totalRacers; i++) {
                //					_statistics = RankManager.instance.racerRanks[i].racer.GetComponent<Statistics>();
                //					Debug.Log ("position "+i+" : "+_statistics.racerDetails.racerName);
                //					if(raceResults[i].name.text=="you"){
                //						OurPosition = i;
                //					}
                //				}
                //	Debug.Log ("our position "+player.rank);
                //for (int i = 0; i < RankManager.instance.totalRacers; i++)
                int TotalMinRacers = Mathf.Clamp(RankManager.instance.totalRacers, 1, 6);
                for (int i = 0; i < TotalMinRacers; i++)
                {
                    Statistics _statistics = RankManager.instance.racerRanks[i].racer.GetComponent<Statistics>();

                    if (_statistics == null) return;

                    //Position
                    if (raceResults[i].position) raceResults[i].position.text = _statistics.rank.ToString();


                    //Name
                    if (raceResults[i].name)
                    {
                        if (RaceManager.instance._raceType != RaceManager.RaceType.SpeedTrap)
                        {
                            raceResults[i].name.text = _statistics.racerDetails.racerName;

                            raceResults[i].countryImg.GetComponent<Image>().sprite = ProfilePics[MenuManager.ProfilePicNo - 1];//uday
                                                                                                                               //							print("************ this is speed trap race type");
                            if (_statistics.racerDetails.myFlag != null) {
                                //																racingUI.inRaceStandings [i].countryImg.GetComponent<Image> ().sprite = _statistics.racerDetails.myFlag;
                                raceResults[i].countryImg.GetComponent<Image>().sprite = _statistics.racerDetails.myFlag;

                            }
                        }
                        else {
                            raceResults[i].name.text = _statistics.racerDetails.racerName + " [" + RankManager.instance.racerRanks[i].speedRecord + " mph]";
                            //							if (_statistics.racerDetails.myFlag != null) {
                            //								racingUI.inRaceStandings [i].countryImg.GetComponent<Image> ().sprite = _statistics.racerDetails.myFlag;
                            ////								raceResults[i].countryImg.GetComponent<Image>().sprite = _statistics.racerDetails.myFlag[_statistics.racerDetails.aiFlag]; // nawaz
                            ////								print("ai flag");
                            //
                            //							}
                            //							raceResults[i].countryImg.GetComponent<Image>().sprite= ProfilePics [i];//uday

                            if (_statistics.racerDetails.myFlag != null) {
                                if (_statistics.racerDetails.myFlag == ProfilePics[MenuManager.ProfilePicNo - 1]) {

                                    racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite = ProfilePics[15];
                                }
                                else
                                    racingUI.inRaceStandings[i].countryImg.GetComponent<Image>().sprite = _statistics.racerDetails.myFlag;


                            }

                            //							

                        }
                    }

                    //Total Race Time
                    if (raceResults[i].totalTime)
                    {
                        if (_statistics.finishedRace && !_statistics.knockedOut)
                        {
                            raceResults[i].totalTime.text = _statistics.totalRaceTime;

                            PlayerTotalTime.text = player.totalRaceTime.ToString();//uday
                        }
                        else if (_statistics.knockedOut)
                        {
                            raceResults[i].totalTime.text = "Knocked Out";
                        }
                        else
                        {
                            raceResults[i].totalTime.text = "Running...";
                        }
                    }

                    //Best Lap Time
                    if (raceResults[i].bestLapTime)
                    {
                        raceResults[i].bestLapTime.text = (_statistics.bestLapTime == string.Empty) ? "--:--:--" : _statistics.bestLapTime;
                    }

                    //Vehicle Name
                    if (raceResults[i].vehicleName)
                    {
                        raceResults[i].vehicleName.text = _statistics.racerDetails.vehicleName;
                    }
                }
            }
        }

        /// <summary>
        /// Gets drift information from the driftpointcontroller and displays them
        /// This function is only called for drift races because of different UI setup
        /// </summary>
        void ShowDriftResults()
        {

            if (driftpointcontroller)
            {
                if (driftResults.totalPoints)
                    driftResults.totalPoints.text = "Total Points : " + driftpointcontroller.totalDriftPoints.ToString("N0");

                if (driftResults.driftRaceTime)
                    driftResults.driftRaceTime.text = "Time : " + driftpointcontroller.GetComponent<Statistics>().totalRaceTime;

                if (driftResults.bestDrift)
                    driftResults.bestDrift.text = "Best Drift : " + driftpointcontroller.bestDrift.ToString("N0") + " pts";

                if (driftResults.longestDrift)
                    driftResults.longestDrift.text = "Longest Drift : " + driftpointcontroller.longestDrift.ToString("0.00") + " s";

                if (driftResults.gold)
                    driftResults.gold.gameObject.SetActive(driftpointcontroller.GetComponent<Statistics>().rank == 1);

                if (driftResults.silver)
                    driftResults.silver.gameObject.SetActive(driftpointcontroller.GetComponent<Statistics>().rank == 2);

                if (driftResults.bronze)
                    driftResults.bronze.gameObject.SetActive(driftpointcontroller.GetComponent<Statistics>().rank > 2);
            }
        }

        public void ShowReplayUI()
        {
            //Display the replay progress bar
            if (progressBar)
                progressBar.fillAmount = ReplayManager.instance.ReplayPercent;
        }

        //Used to show useful race info
        public void ShowRaceInfo(string info, float time, Color c)
        {
            StartCoroutine(RaceInfo(info, time, c));
        }

        IEnumerator RaceInfo(string info, float time, Color c)
        {
            if (!racingUI.raceInfo)
                yield break;

            if (racingUI.raceInfo.text == "")
            {
                racingUI.raceInfo.text = info;

                Color col = c;
                col.a = 1.0f;
                racingUI.raceInfo.color = col;

                yield return new WaitForSeconds(time);

                //Do Fade Out
                while (col.a > 0.0f)
                {
                    col.a -= Time.deltaTime * 2.0f;
                    racingUI.raceInfo.color = col;
                    yield return null;
                }

                if (col.a <= 0.01f)
                {
                    racingUI.raceInfo.text = string.Empty;
                }

                //Check if there are any other race infos that need to be displayed
                CheckRaceInfoList();
            }
            else
            {
                raceInfos.Add(info);
            }
        }

        public IEnumerator ShowDriftRaceInfo(string info, Color c)
        {
            if (!driftUI.driftStatus) yield break;

            driftUI.driftStatus.text = info;
            driftUI.driftStatus.color = c;

            yield return new WaitForSeconds(2.0f);

            driftUI.driftStatus.text = string.Empty;
        }

        public void CheckRaceInfoList()
        {
            if (raceInfos.Count > 0)
            {
                ShowRaceInfo(raceInfos[raceInfos.Count - 1], 2.0f, Color.white);
                raceInfos.RemoveAt(raceInfos.Count - 1);
            }
        }

        void WrongwayUI()
        {
            //Wrong way indication
            if (racingUI.wrongwayText)
            {
                if (player.GetComponent<Statistics>().goingWrongway)
                {
                    racingUI.wrongwayText.text = "Wrong Way!";
                }
                else
                {
                    racingUI.wrongwayText.text = string.Empty;
                }
            }

            if (racingUI.wrongwayImage)
            {
                if (player.GetComponent<Statistics>().goingWrongway)
                {
                    racingUI.wrongwayImage.enabled = true;
                }
                else
                {
                    racingUI.wrongwayImage.enabled = false;
                }
            }
        }

        string GetPrevLapTime()
        {
            if (player.prevLapTime != "")
            {
                return "Last " + player.prevLapTime;
            }
            else
            {
                return "Last --:--:--";
            }
        }

        public string GetBestLapTime()
        {
            if (PlayerPrefs.HasKey("BestTime" + SceneManager.GetActiveScene().name))
            {
                return PlayerPrefs.GetString("BestTime" + SceneManager.GetActiveScene().name);
            }
            else
            {
                return "--:--:--";
            }
        }
        public GameObject[] lightcolor;
        public void SetCountDownText(string value)
        {
            if (!racingUI.countdown) return;

            racingUI.countdown.text = value;

            Debug.Log("value::" + value);

            if (value == "3") {
                //				lightcolor [0].GetComponent<MeshRenderer> ().materials [0].color = new Color32 (90,0,0,255);

                lightcolor[0].SetActive(true);
                lightcolor[1].SetActive(true);
                lightcolor[2].SetActive(true);
                lightcolor[3].SetActive(true);

                lightcolor[4].SetActive(false);

                lightcolor[5].SetActive(false);

                SoundManager.instance.countDown.Play();



            } else if (value == "2") {
                lightcolor[0].SetActive(true);
                lightcolor[1].SetActive(true);
                lightcolor[2].SetActive(true);
                lightcolor[3].SetActive(true);

                lightcolor[4].SetActive(true);

                lightcolor[5].SetActive(false);

                SoundManager.instance.countDown.Play();


            } else if (value == "1") {
                lightcolor[0].SetActive(true);
                lightcolor[1].SetActive(true);
                lightcolor[2].SetActive(true);
                lightcolor[3].SetActive(true);

                lightcolor[4].SetActive(true);

                lightcolor[5].SetActive(true);

                SoundManager.instance.countDown.Play();

            }
            else if (value == "GO!")

            {
                lightcolor[0].SetActive(false);
                lightcolor[1].SetActive(false);
                lightcolor[2].SetActive(false);
                lightcolor[3].SetActive(false);

                lightcolor[4].SetActive(false);

                lightcolor[5].SetActive(false);

                //				Car_Controller.mee.engineAudioSource.Play ();


                //				RaceManager.instance.raceStarted = true;
            }
            //			iTween.ScaleFrom (racingUI.countdown.gameObject, iTween.Hash ("x", 0, "y", 0, "time", 0.5));
            //			iTween.RotateFrom (racingUI.countdown.gameObject, iTween.Hash ("z", 90, "time", 0.5));
            //			iTween.ColorFrom (racingUI.countdown.gameObject, iTween.Hash ("alpha", 1, "y", 0, "time", 0.5));

            //			iTween.ColorFrom(racingUI.countdown.gameObject,iTween.Hash("g", 2, "time", 0.3, "delay",0.3)); 

        }

        public void SetFailRace(string title, string reason)
        {
            if (failTitle) failTitle.text = title;

            if (failReason) failReason.text = reason;
        }

        /// <summary>
        /// Gets rid of all other UI apart from the FinishedText to show the "Race Completed" text in the End Race Rountine
        /// </summary>
        public void DisableRacePanelChildren()
        {
            if (!racingUI.finishedText) return;

            RectTransform[] rectTransforms = racePanel.GetComponentsInChildren<RectTransform>();

            foreach (RectTransform t in rectTransforms)
            {
                if (t != racePanel.GetComponent<RectTransform>() && t != racingUI.finishedText.GetComponent<RectTransform>())
                {
                    t.gameObject.SetActive(false);
                }
            }
        }

        public void SetFinishedText(string word)
        {
            if (racingUI.finishedText)
                racingUI.finishedText.text = word;
        }

        int CurrentLevelScore;
        public void SetRewardText(int currency, int pos)
        {
            if (rewardTexts.rewardCurrency) {

                if (pos <= 3) {
                    if (pos == 2) {
                        currency = int.Parse("" + (currency * 0.75f));

                    } else if (pos == 3) {
                        currency = int.Parse("" + (currency * 0.5f));
                    }
                    PlayerData.AddCurrency(currency);
                } else {
                    currency = 0;

                }

                CurrentLevelScore = currency;
                rewardTexts.rewardCurrency.text = "" + currency;
            }


            rewardTexts.RacePosTxt.text = "" + pos;

            if (rewardTexts.racePosTag) {
                if (pos == 1 || pos == 21) {
                    rewardTexts.racePosTag.text = "st";
                }
                else if (pos == 2 || pos == 22) {
                    rewardTexts.racePosTag.text = "nd";
                }

                else if (pos == 3 || pos == 23) {
                    rewardTexts.racePosTag.text = "rd";
                }
                else {
                    rewardTexts.racePosTag.text = "th";
                }
            }


            TotalCurrencytxt.text = " " + PlayerData.currency.ToString("NO");//venkat
            Currentlvltxt.text = "stage " + MenuManager.CurrentLevel;

        }


        #region Screen Fade
        public IEnumerator ScreenFadeOut(float speed)
        {
            //Get the color
            Color col = screenFade.color;
            if (col.a > 0.0f) yield break;

            //Change the alpha to 1
            col.a = 1;
            screenFade.color = col;

            //Fade out
            while (col.a > 0.0f)
            {
                col.a -= Time.deltaTime * speed;
                screenFade.color = col;
                yield return null;
            }
        }

        public IEnumerator ScreenFadeIn(float speed, bool loadScene, string scene)
        {
            //Get the color
            Color col = screenFade.color;

            //Change the alpha to 0
            col.a = 0;
            screenFade.color = col;

            //Fade in
            while (col.a < 1.0f)
            {
                col.a += Time.deltaTime * speed;
                screenFade.color = col;
                yield return null;

                //Load the menu scene when fade completes
                if (col.a >= 1.0f)
                    SceneManager.LoadScene(scene);
            }

        }
        #endregion

        #region UI Button Functions

        public void StartCountDown(float time)
        {
            StartCoroutine(RaceManager.instance.Countdown(time));
        }

        public void PauseResume()
        {
            RaceManager.instance.PauseRace();
        }

        public void Restart()
        {
            //unpause inorder to reset timescale & audiolistener vol
            if (RaceManager.instance._raceState == RaceManager.RaceState.Paused)
            {
                PauseResume();
            }

            if (fadeOnExit && screenFade)
            {
                StartCoroutine(ScreenFadeIn(fadeSpeed * 2, true, SceneManager.GetActiveScene().name));
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void Exit()
        {
            //unpause inorder to reset timescale & audiolistener vol
            if (RaceManager.instance._raceState == RaceManager.RaceState.Paused)
            {
                PauseResume();
            }

            if (fadeOnExit && screenFade)
            {
                StartCoroutine(ScreenFadeIn(fadeSpeed * 2, true, menuScene));
            }
            else
            {
                SceneManager.LoadScene(menuScene);
            }
        }
        public GameObject LoadingPanelNew;
        void CloseLoading()
        {
            LoadingPanelNew.SetActive(false);

        }
        public void NextLevel()
        {
            LoadingPanelNew.SetActive(true);
            MenuManager.ComingForUpgrade = true;

            //			MenuManager.ComingForUpgrade = false;
            ShowAdLc();
            Invoke("loadMenu", 1.3f);
            //SceneManager.LoadScene(menuScene);


        }
        void loadMenu()
        {
            SceneManager.LoadScene(menuScene);
        }

		public void Trucks_RetryClicked()
		{
//			MenuManager.mee.trackIndex=Levelmanager.RetryLevelNum;
			Debug.Log ("Ttrack index afer clicking on retry btn::"+Levelmanager.RetryLevelNum);
            Time.timeScale = 1;
            LoadingPanelNew.SetActive(true);
            MenuManager.ComingForUpgrade = true;
            Invoke("loadMenu", 1.3f);
            //SceneManager.LoadScene (menuScene);

        }

		public GameObject HelpPopups;
		public void EnableHelpPopups()
		{
			HelpPopups.SetActive (true);
		}


		public void WatchVideoToGetFullNitro_NoBtnClicked()
		{
			startingGridPanel.SetActive (false);
			Time.timeScale = 0;
			Levelmanager.mee.EnableHelpPopups ();

//			Time.timeScale = 0;

			Debug.Log ("No Btn CLICK+++++++++++++++++++++++++++++++");


		}

		public void HelpPopup_ContinueBtnClicked()
		{

			HelpPopups.SetActive (false);
			Time.timeScale = 1;

//			RaceUI.instance.StartCountDown (1);

			Debug.Log ("Help Continue---------------------------------");
			startingGridPanel.SetActive (false);
			AudioListener.volume = 1;
            
		}

		public void WatchVideoToGetFullNitro_YesBtnClicked()
		{
			#if UNITY_EDITOR
			Debug.Log("------ Menu Watched video successfully");
			player.GetComponent<Car_Controller> ().nitroCapacity = 1;
			startingGridPanel.SetActive (false);
			Levelmanager.mee.EnableHelpPopups ();
#endif

            //	AdManager.instance.ShowRewardVideoWithCallback ((result)=>         //venkat
            //	{
            //		if(result)
            //		{
                      //  AdManager.instance.DisplayvideoAd();
						int coins=PlayerPrefs.GetInt("MyCoins",500);
//						coins+=1000;
//						PlayerPrefs.SetInt("MyCoins",coins);
//						CoinsTxt.text="Coins:"+coins;
						Debug.Log("------ Menu Watched video successfully");
						player.GetComponent<Car_Controller> ().nitroCapacity = 1;
						startingGridPanel.SetActive (false);
						Levelmanager.mee.EnableHelpPopups ();

//						CoinsAddedPopUp.instance.Open(1000,AdManager.RewardDescType.WatchVideo);
				//	}
			//	});  //venkat
		}


		public void Pause_RetryClicked()
		{
            //			failRacePanel.SetActive (true);
            //			pausePanel.SetActive (false);
            LoadingPanelNew.SetActive(true);
            ShowAdLf();
			//Application.LoadLevel(Application.loadedLevelName);
			Time.timeScale = 1;
            Invoke("gotoretrylevel", 1.3f);


        }
        void gotoretrylevel()
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
		public void Pause_MenuClicked()
		{
			Time.timeScale = 1;
			SceneManager.LoadScene (menuScene);
			MenuManager.ComingForUpgrade = true;
//			MenuManager.State=MenuManager.mee.vehi
		}
        #endregion
    }



}