public class ShipInfo
{
    private int hitPoints;
    private int lives;
    private int pointValue;

    public ShipInfo(int hitPoints, int lives, int pointValue) {
        this.hitPoints = hitPoints;
        this.lives = lives;
        this.pointValue = pointValue;
    }

    public int getHitPoints() {
        return hitPoints;
    }

    public int getLives() {
        return lives;
    }

    public int getPointValue() {
        return pointValue;
    }
}
