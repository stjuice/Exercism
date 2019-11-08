using System;

public class SpaceAge
{
    int age;
    const double EarthSeconds = 365.25 * 60 * 60 * 24;
    const double MercurySeconds = EarthSeconds * 0.2408467;
    const double VenusSeconds = EarthSeconds * 0.61519726;
    const double MarsSeconds = EarthSeconds * 1.8808158;
    const double JupiterSeconds = EarthSeconds * 11.862615;
    const double SaturnSeconds = EarthSeconds * 29.447498;
    const double UranusSeconds = EarthSeconds * 84.016846;
    const double NeptuneSeconds = EarthSeconds * 164.79132;
   
    public SpaceAge(int seconds) => age = seconds;

    public double OnEarth() => this.age / EarthSeconds;

    public double OnMercury() => this.age / MercurySeconds;

    public double OnVenus() => this.age / VenusSeconds;

    public double OnMars() => this.age / MarsSeconds;

    public double OnJupiter() => this.age / JupiterSeconds;

    public double OnSaturn() => this.age / SaturnSeconds;

    public double OnUranus() => this.age / UranusSeconds;

    public double OnNeptune() => this.age / NeptuneSeconds;
}